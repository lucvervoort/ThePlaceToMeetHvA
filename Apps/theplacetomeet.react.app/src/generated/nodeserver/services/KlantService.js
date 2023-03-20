/* eslint-disable no-unused-vars */
const Service = require('./Service');

/**
*
* klant Klant  (optional)
* no response value expected for this operation
* */
const customerAdd = ({ klant }) => new Promise(
  async (resolve, reject) => {
    try {
      resolve(Service.successResponse({
        klant,
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
const customerCustomers = () => new Promise(
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
/**
*
* email String 
* returns Klant
* */
const customerGetByEmail = ({ email }) => new Promise(
  async (resolve, reject) => {
    try {
      resolve(Service.successResponse({
        email,
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
  customerAdd,
  customerCustomers,
  customerGetByEmail,
};
