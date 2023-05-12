import React, { useContext, useEffect } from "react";
import Card from 'react-bootstrap/Card';

import { VenueContext } from "../../providers/VenueProvider";
import { useParams } from "react-router-dom";

const Venue = () => {
    const { venue, getVenueById } = useContext(VenueContext);
    const { id } = useParams();

    useEffect(() => {
        getVenueById();
    }, [id]);

    return (
        <Card style={{ width: '400rem' }}>
            <Card.Body>
                <Card.Title>{venueName}</Card.Title>
                <Card.Text>{venueDescription}</Card.Text>
            </Card.Body>
            <ListGroup className='list-group-center'>
                <ListGroup.Item>Zip Code: {venueZipcode}</ListGroup.Item>
                <ListGroup.Item>Capacity: {capacity}</ListGroup.Item>
                <ListGroup.Item>Venue Rate: ${venueRate} per event</ListGroup.Item>
            </ListGroup>
            <Card.Body>
                {venue.users.map((user) => {
                    return (
                        <Card.Link href="user">Venue Owner: {user.userName}</Card.Link>
                    )
                })}
            </Card.Body>
        </Card>
    )
};

export default Venue;