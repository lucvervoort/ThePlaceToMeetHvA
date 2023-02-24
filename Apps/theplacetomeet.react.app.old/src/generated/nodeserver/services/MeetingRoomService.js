/* eslint-disable no-unused-vars */
const Service = require('./Service');

/**
*
* id Integer 
* returns MeetingRoom
* */
const meetingRoomGetById = ({ id }) => new Promise(
  async (resolve, reject) => {
    try {
      resolve(Service.successResponse({
        id,
      }));
    } catch (e) {
      reject(Service.rejectResponse(
        e.message || 'Invalid input',
        e.status || 405,
      ));
    }
  },
);
/**
*
* maxAantalPersonen String 
* maaxNumberOfPersons Integer  (optional)
* returns List
* */
const meetingRoomGetByMaxAantalPersonen = ({ maxAantalPersonen, maaxNumberOfPersons }) => new Promise(
  async (resolve, reject) => {
    try {
      resolve(Service.successResponse({
        maxAantalPersonen,
        maaxNumberOfPersons,
      }));
    } catch (e) {
      reject(Service.rejectResponse(
        e.message || 'Invalid input',
        e.status || 405,
      ));
    }
  },
);
/**
*
* returns List
* */
const meetingRoomMeetingRooms = () => new Promise(
  async (resolve, reject) => {
    try {
      resolve(Service.successResponse({
      }));
    } catch (e) {
      reject(Service.rejectResponse(
        e.message || 'Invalid input',
        e.status || 405,
      ));
    }
  },
);

module.exports = {
  meetingRoomGetById,
  meetingRoomGetByMaxAantalPersonen,
  meetingRoomMeetingRooms,
};
