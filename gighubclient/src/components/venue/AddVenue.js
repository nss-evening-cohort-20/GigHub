import React, { useEffect, useState } from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import { useNavigate } from 'react-router-dom';
import "./VenueList";


const AddVenue = () => {
  const [newVenue, update] = useState({
    venueName: '',
    venueDescription: '',
    venueZipcode: '',
    capacity: '',
    venueRate: '',
  });

  const [venues, setVenues] = useState([]);

  const navigate = useNavigate();

  useEffect(() => {
    const fetchVenues = async () => {
        const response = await fetch ('/venue')
        const venueArray = await response.json();
        setVenues(venueArray);
    };
    fetchVenues();
  },
  {});

  const handleSubmit = (event) => {
    event.preventDefault();
    
    const dataToSendToAPI = {
        venueName: newVenue.venueName,
        venueDescription: newVenue.venueDescription,
        venueZipcode: newVenue.venueZipcode,
        capacity: newVenue.capacity,
        venueRate: newVenue.venueRate,
    };

    return fetch('/venue', {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify(dataToSendToAPI)
    })
        .then((response) => response.json())
        .then(() => {
            navigate('/');
        });
  };

  return (
    <div className="add-venue-form">
    <div className="page-title">Add New Venue</div>
        <Form>
        <Form.Group className="form-group" controlId="formBasicName">
            <Form.Label>Venue Name</Form.Label>
            <Form.Control placeholder="Enter Venue Name" />
        </Form.Group>

        <Form.Group className="form-group" controlId="formBasicDescription">
            <Form.Label>Description</Form.Label>
            <Form.Control as="textarea" rows={3} />
        </Form.Group>

        <Form.Group className="form-group" controlId="formBasicZipcode">
            <Form.Label>Zip Code</Form.Label>
            <Form.Control placeholder="Enter Venue Zip Code" />
        </Form.Group>

        <Form.Group className="form-group" controlId="formBasicCapacity">
            <Form.Label>Capacity</Form.Label>
            <Form.Control placeholder="Enter Venue Capacity" />
        </Form.Group>

        <Form.Group className="form-group" controlId="formBasicZipcode">
            <Form.Label>Venue Rate</Form.Label>
            <Form.Control placeholder="Event Venue Rate" />
        </Form.Group>

        <Button variant="primary" type="submit"
            onClick={(clickEvent) => handleSubmit(clickEvent)}
            className="btn btn-primary">
            Submit
        </Button>
        </Form>
    </div>
  );
//   return (
//     <div className="add-venue">
//       <div className="page-title">Add New Venue</div>
//       <form onSubmit={handleSubmit}>
//         <div className="form-group">
//           <label htmlFor="venueName">Venue Name</label>
//           <input
//             type="text"
//             id="venueName"
//             value={venueName}
//             onChange={(event) => setVenueName(event.target.value)}
//             required
//           />
//         </div>
//         <div className="form-group">
//           <label htmlFor="venueDescription">Venue Description</label>
//           <textarea
//             id="venueDescription"
//             value={venueDescription}
//             onChange={(event) => setVenueDescription(event.target.value)}
//             required
//           />
//         </div>
//         <div className="form-group">
//           <label htmlFor="venueZipcode">Zip Code</label>
//           <input
//             type="text"
//             id="venueZipcode"
//             value={venueZipcode}
//             onChange={(event) => setVenueZipcode(event.target.value)}
//             required
//           />
//         </div>
//         <div className="form-group">
//           <label htmlFor="capacity">Capacity</label>
//           <input
//             type="number"
//             id="capacity"
//             value={capacity}
//             onChange={(event) => setCapacity(event.target.value)}
//             required
//           />
//         </div>
//         <div className="form-group">
//           <label htmlFor="venueRate">Venue Rate</label>
//           <input
//             type="number"
//             id="venueRate"
//             value={venueRate}
//             onChange={(event) => setVenueRate(event.target.value)}
//             required
//           />
//         </div>
//         <button
//             className="addVenue"
//             onClick={(clickEvent) => {
//               handleSubmit(clickEvent);
//             }}
//           >
//             Add Venue
//           </button>
//       </form>
//     </div>
//   );
};

export default AddVenue;