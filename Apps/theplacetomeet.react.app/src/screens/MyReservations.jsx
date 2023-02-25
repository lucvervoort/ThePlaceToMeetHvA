import React, { useEffect, useState } from "react";

const MyReservationsView = () => {

  const [reservations, setReservations] = useState();
  // Function to collect data
  const getReservations = async () => {
        const response = await fetch(
            "https://demo.alles-online.be:7045/Reservation/"
      ).then((response) => response.json());
        console.log(response);
        setReservations(response);
    }

    useEffect(() => {
        getReservations();
    }, []);

  return (
    <div className="mt-4 grow flex items-center justify-around">
    <div className="mb-64">
              <h1 className="text-4xl text-center mb-4">Alle reservaties</h1>

              {reservations &&
                  reservations.map((reservation) => (
                      <div className="item-container" key={reservation.id}>
                          Id: {reservation.id}
                          <div className="title">
                              Tijdstip:{reservation.dag}, beginuur: {reservation.beginUur}, duur: {reservation.duurInUren} aantal personen: {reservation.aantalPersonen}
                          </div>
                      </div>
                  ))}
    </div>
  </div>

  );
};

export default MyReservationsView;
