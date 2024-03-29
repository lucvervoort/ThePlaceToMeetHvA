/**
 * ThePlaceToMeet.WebApi
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 *
 */


import ApiClient from "../ApiClient";
import Customer from '../model/Customer';
import ProblemDetails from '../model/ProblemDetails';

/**
* Customer service.
* @module api/CustomerApi
* @version 1.0
*/
export default class CustomerApi {

    /**
    * Constructs a new CustomerApi. 
    * @alias module:api/CustomerApi
    * @class
    * @param {module:ApiClient} [apiClient] Optional API client implementation to use,
    * default to {@link module:ApiClient#instance} if unspecified.
    */
    constructor(apiClient) {
        this.apiClient = apiClient || ApiClient.instance;
    }


    /**
     * Callback function to receive the result of the customerAdd operation.
     * @callback module:api/CustomerApi~customerAddCallback
     * @param {String} error Error message, if any.
     * @param data This operation does not return a value.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {Object} opts Optional parameters
     * @param {module:model/Customer} opts.customer 
     * @param {module:api/CustomerApi~customerAddCallback} callback The callback function, accepting three arguments: error, data, response
     */
    customerAdd(opts, callback) {
      opts = opts || {};
      let postBody = opts['customer'];

      let pathParams = {
      };
      let queryParams = {
      };
      let headerParams = {
      };
      let formParams = {
      };

      let authNames = [];
      let contentTypes = ['application/json'];
      let accepts = ['application/json'];
      let returnType = null;
      return this.apiClient.callApi(
        '/Customer', 'POST',
        pathParams, queryParams, headerParams, formParams, postBody,
        authNames, contentTypes, accepts, returnType, null, callback
      );
    }

    /**
     * Callback function to receive the result of the customerCustomers operation.
     * @callback module:api/CustomerApi~customerCustomersCallback
     * @param {String} error Error message, if any.
     * @param {Array.<module:model/Customer>} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {module:api/CustomerApi~customerCustomersCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link Array.<module:model/Customer>}
     */
    customerCustomers(callback) {
      let postBody = null;

      let pathParams = {
      };
      let queryParams = {
      };
      let headerParams = {
      };
      let formParams = {
      };

      let authNames = [];
      let contentTypes = [];
      let accepts = ['application/json'];
      let returnType = [Customer];
      return this.apiClient.callApi(
        '/Customer', 'GET',
        pathParams, queryParams, headerParams, formParams, postBody,
        authNames, contentTypes, accepts, returnType, null, callback
      );
    }

    /**
     * Callback function to receive the result of the customerGetByEmail operation.
     * @callback module:api/CustomerApi~customerGetByEmailCallback
     * @param {String} error Error message, if any.
     * @param {module:model/Customer} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {String} email 
     * @param {module:api/CustomerApi~customerGetByEmailCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link module:model/Customer}
     */
    customerGetByEmail(email, callback) {
      let postBody = null;
      // verify the required parameter 'email' is set
      if (email === undefined || email === null) {
        throw new Error("Missing the required parameter 'email' when calling customerGetByEmail");
      }

      let pathParams = {
        'email': email
      };
      let queryParams = {
      };
      let headerParams = {
      };
      let formParams = {
      };

      let authNames = [];
      let contentTypes = [];
      let accepts = ['application/json'];
      let returnType = Customer;
      return this.apiClient.callApi(
        '/Customer/{email}', 'GET',
        pathParams, queryParams, headerParams, formParams, postBody,
        authNames, contentTypes, accepts, returnType, null, callback
      );
    }


}
