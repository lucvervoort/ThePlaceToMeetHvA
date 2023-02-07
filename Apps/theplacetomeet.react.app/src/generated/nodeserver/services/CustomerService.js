/* eslint-disable no-unused-vars */
const Service = require('./Service');

/**
*
* customer Customer  (optional)
* no response value expected for this operation
* */
const customerAdd = ({ customer }) => new Promise(
  async (resolve, reject) => {
    try {
      resolve(Service.successResponse({
        customer,
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
* returns Customer
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
