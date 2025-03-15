import React, { useState, useEffect } from 'react';

export default function BowlerTable() {
    const [bowlers, setBowlers] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        // Fetch data from the API
        fetch('https://localhost:7095/api/bowlers')  // Adjust port if needed
            .then(response => response.json())
            .then(data => {
                setBowlers(data);
                setLoading(false);
            })
            .catch(error => console.error('Error fetching bowler data:', error));
    }, []);

    if (loading) {
        return <p>Loading bowler data...</p>;
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
            {bowlers.map(bowler => (
                <tr key={bowler.bowlerID}>
                    <td>{`${bowler.bowlerFirstName} ${bowler.bowlerMiddleInit || ''} ${bowler.bowlerLastName}`}</td>
                    <td>{bowler.team.teamName}</td>
                    <td>{bowler.bowlerAddress}</td>
                    <td>{bowler.bowlerCity}</td>
                    <td>{bowler.bowlerState}</td>
                    <td>{bowler.bowlerZip}</td>
                    <td>{bowler.bowlerPhoneNumber}</td>
                </tr>
            ))}
            </tbody>
        </table>
    );
}