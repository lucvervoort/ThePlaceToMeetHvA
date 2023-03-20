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
import Catering from '../model/Catering';
import ProblemDetails from '../model/ProblemDetails';

/**
* Catering service.
* @module api/CateringApi
* @version 1.0
*/
export default class CateringApi {

    /**
    * Constructs a new CateringApi. 
    * @alias module:api/CateringApi
    * @class
    * @param {module:ApiClient} [apiClient] Optional API client implementation to use,
    * default to {@link module:ApiClient#instance} if unspecified.
    */
    constructor(apiClient) {
        this.apiClient = apiClient || ApiClient.instance;
    }


    /**
     * Callback function to receive the result of the cateringCaterings operation.
     * @callback module:api/CateringApi~cateringCateringsCallback
     * @param {String} error Error message, if any.
     * @param {Array.<module:model/Catering>} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {module:api/CateringApi~cateringCateringsCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link Array.<module:model/Catering>}
     */
    cateringCaterings(callback) {
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
      let returnType = [Catering];
      return this.apiClient.callApi(
        '/Catering', 'GET',
        pathParams, queryParams, headerParams, formParams, postBody,
        authNames, contentTypes, accepts, returnType, null, callback
      );
    }

    /**
     * Callback function to receive the result of the cateringGetBy operation.
     * @callback module:api/CateringApi~cateringGetByCallback
     * @param {String} error Error message, if any.
     * @param {module:model/Catering} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {Number} id 
     * @param {module:api/CateringApi~cateringGetByCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link module:model/Catering}
     */
    cateringGetBy(id, callback) {
      let postBody = null;
      // verify the required parameter 'id' is set
      if (id === undefined || id === null) {
        throw new Error("Missing the required parameter 'id' when calling cateringGetBy");
      }

      let pathParams = {
        'id': id
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
      let returnType = Catering;
      return this.apiClient.callApi(
        '/Catering/{id}', 'GET',
        pathParams, queryParams, headerParams, formParams, postBody,
        authNames, contentTypes, accepts, returnType, null, callback
      );
    }


}