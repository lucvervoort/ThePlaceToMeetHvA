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


import ApiClient from './ApiClient';
import Catering from './model/Catering';
import Customer from './model/Customer';
import Discount from './model/Discount';
import MeetingRoom from './model/MeetingRoom';
import MeetingRoomType from './model/MeetingRoomType';
import ProblemDetails from './model/ProblemDetails';
import Reservation from './model/Reservation';
import CateringApi from './api/CateringApi';
import CustomerApi from './api/CustomerApi';
import MeetingRoomApi from './api/MeetingRoomApi';


/**
* JS API client generated by OpenAPI Generator.<br>
* The <code>index</code> module provides access to constructors for all the classes which comprise the public API.
* <p>
* An AMD (recommended!) or CommonJS application will generally do something equivalent to the following:
* <pre>
* var ThePlaceToMeetWebApi = require('index'); // See note below*.
* var xxxSvc = new ThePlaceToMeetWebApi.XxxApi(); // Allocate the API class we're going to use.
* var yyyModel = new ThePlaceToMeetWebApi.Yyy(); // Construct a model instance.
* yyyModel.someProperty = 'someValue';
* ...
* var zzz = xxxSvc.doSomething(yyyModel); // Invoke the service.
* ...
* </pre>
* <em>*NOTE: For a top-level AMD script, use require(['index'], function(){...})
* and put the application logic within the callback function.</em>
* </p>
* <p>
* A non-AMD browser application (discouraged) might do something like this:
* <pre>
* var xxxSvc = new ThePlaceToMeetWebApi.XxxApi(); // Allocate the API class we're going to use.
* var yyy = new ThePlaceToMeetWebApi.Yyy(); // Construct a model instance.
* yyyModel.someProperty = 'someValue';
* ...
* var zzz = xxxSvc.doSomething(yyyModel); // Invoke the service.
* ...
* </pre>
* </p>
* @module index
* @version 1.0
*/
export {
    /**
     * The ApiClient constructor.
     * @property {module:ApiClient}
     */
    ApiClient,

    /**
     * The Catering model constructor.
     * @property {module:model/Catering}
     */
    Catering,

    /**
     * The Customer model constructor.
     * @property {module:model/Customer}
     */
    Customer,

    /**
     * The Discount model constructor.
     * @property {module:model/Discount}
     */
    Discount,

    /**
     * The MeetingRoom model constructor.
     * @property {module:model/MeetingRoom}
     */
    MeetingRoom,

    /**
     * The MeetingRoomType model constructor.
     * @property {module:model/MeetingRoomType}
     */
    MeetingRoomType,

    /**
     * The ProblemDetails model constructor.
     * @property {module:model/ProblemDetails}
     */
    ProblemDetails,

    /**
     * The Reservation model constructor.
     * @property {module:model/Reservation}
     */
    Reservation,

    /**
    * The CateringApi service constructor.
    * @property {module:api/CateringApi}
    */
    CateringApi,

    /**
    * The CustomerApi service constructor.
    * @property {module:api/CustomerApi}
    */
    CustomerApi,

    /**
    * The MeetingRoomApi service constructor.
    * @property {module:api/MeetingRoomApi}
    */
    MeetingRoomApi
};
