import React, { useEffect, useState } from "react";
import axios from "axios";
import meetingpic from "../images/meeting.jpg";
import brainstorm from "../images/brainstorm.jpg";
import breakout from "../images/breakout.jpg";

const ReservationView = () => {
  const [meetingRooms, setMeetingRooms] = useState([]);

  useEffect(() => {
    axios.get("/MeetingRoom").then((response) => {
      setMeetingRooms(response.data);
    });
  }, []);

  console.log(meetingRooms);

  const getMeetingroomImage = (vergaderruimteType) => {
    switch (vergaderruimteType) {
      case 0:
        return brainstorm;
      case 1:
        return breakout;
      case 2:
        return meetingpic;
    }
  };

  return (
    <div className="flex flex-col justify-items-center mt-14">
      <div className="flex justify-around">
        {" "}
        <h1 className="text-4xl mb-4">Reserveer een vergaderruimte</h1>
      </div>
      <div className="flex justify-around">
        <div className="mt-8 grid gap-6 grid-cols-2 md:grid-cols-3 lg:grid-cols-3">
          {meetingRooms.length > 0 &&
            meetingRooms.map((meetingRoom) => (
              <div className="flex flex-col items-center">
                <div className="text-center font-bold"> {meetingRoom.naam}</div>
                <div className="text-center text-xs pt-4">
                  Maximaal {meetingRoom.maximumAantalPersonen} personen
                </div>
                <div className="rounded-2xl flex pt-4">
                  <img
                    className="rounded-2xl object-cover aspect-auto"
                    src={getMeetingroomImage(meetingRoom.vergaderruimteType)}
                    alt=""
                  />
                </div>
              </div>
            ))}
        </div>
      </div>
    </div>
  );
};

export default ReservationView;
