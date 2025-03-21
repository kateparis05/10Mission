import React, { useState, useEffect } from 'react';

export default function BowlerTable() {
    const [bowlers, setBowlers] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        // Fetch data from the API
        fetch('http://localhost:5194/api/bowlers')  // Updated to use port 5194
            .then(response => {
                if (!response.ok) {
                    throw new Error(`API returned ${response.status}`);
                }
                return response.json();
            })
            .then(data => {
                console.log('Received data:', data);
                // Extract the actual bowlers array from the response
                const bowlersArray = data.$values || data;
                setBowlers(bowlersArray);
                setLoading(false);
            })
            .catch(err => {
                console.error('Error fetching bowler data:', err);
                setError(err.message);
                setLoading(false);
            });
    }, []);

    if (loading) {
        return <p>Loading bowler data...</p>;
    }

    if (error) {
        return <p>Error loading data: {error}</p>;
    }

    return (
        <table className="table table-striped">
            <thead>
            <tr>
                <th>Name</th>
                <th>Team</th>
                <th>Address</th>
                <th>City</th>
                <th>State</th>
                <th>Zip</th>
                <th>Phone</th>
            </tr>
            </thead>
            <tbody>
            {bowlers.length === 0 ? (
                <tr>
                    <td colSpan="7">No bowlers found</td>
                </tr>
            ) : (
                bowlers.map(bowler => (
                    <tr key={bowler.bowlerID}>
                        <td>{`${bowler.bowlerFirstName} ${bowler.bowlerMiddleInit || ''} ${bowler.bowlerLastName}`}</td>
                        <td>{bowler.team?.teamName || 'No Team'}</td>
                        <td>{bowler.bowlerAddress}</td>
                        <td>{bowler.bowlerCity}</td>
                        <td>{bowler.bowlerState}</td>
                        <td>{bowler.bowlerZip}</td>
                        <td>{bowler.bowlerPhoneNumber}</td>
                    </tr>
                ))
            )}
            </tbody>
        </table>
    );
}