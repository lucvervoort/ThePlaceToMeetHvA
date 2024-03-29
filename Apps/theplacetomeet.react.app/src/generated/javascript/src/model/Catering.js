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

import ApiClient from '../ApiClient';

/**
 * The Catering model module.
 * @module model/Catering
 * @version 1.0
 */
class Catering {
    /**
     * Constructs a new <code>Catering</code>.
     * @alias module:model/Catering
     */
    constructor() { 
        
        Catering.initialize(this);
    }

    /**
     * Initializes the fields of this object.
     * This method is used by the constructors of any subclasses, in order to implement multiple inheritance (mix-ins).
     * Only for internal use.
     */
    static initialize(obj) { 
    }

    /**
     * Constructs a <code>Catering</code> from a plain JavaScript object, optionally creating a new instance.
     * Copies all relevant properties from <code>data</code> to <code>obj</code> if supplied or a new instance if not.
     * @param {Object} data The plain JavaScript object bearing properties of interest.
     * @param {module:model/Catering} obj Optional instance to populate.
     * @return {module:model/Catering} The populated <code>Catering</code> instance.
     */
    static constructFromObject(data, obj) {
        if (data) {
            obj = obj || new Catering();

            if (data.hasOwnProperty('id')) {
                obj['id'] = ApiClient.convertToType(data['id'], 'Number');
            }
            if (data.hasOwnProperty('titel')) {
                obj['titel'] = ApiClient.convertToType(data['titel'], 'String');
            }
            if (data.hasOwnProperty('beschrijving')) {
                obj['beschrijving'] = ApiClient.convertToType(data['beschrijving'], 'String');
            }
            if (data.hasOwnProperty('prijsPerPersoon')) {
                obj['prijsPerPersoon'] = ApiClient.convertToType(data['prijsPerPersoon'], 'Number');
            }
        }
        return obj;
    }

    /**
     * Validates the JSON data with respect to <code>Catering</code>.
     * @param {Object} data The plain JavaScript object bearing properties of interest.
     * @return {boolean} to indicate whether the JSON data is valid with respect to <code>Catering</code>.
     */
    static validateJSON(data) {
        // ensure the json data is a string
        if (data['titel'] && !(typeof data['titel'] === 'string' || data['titel'] instanceof String)) {
            throw new Error("Expected the field `titel` to be a primitive type in the JSON string but got " + data['titel']);
        }
        // ensure the json data is a string
        if (data['beschrijving'] && !(typeof data['beschrijving'] === 'string' || data['beschrijving'] instanceof String)) {
            throw new Error("Expected the field `beschrijving` to be a primitive type in the JSON string but got " + data['beschrijving']);
        }

        return true;
    }


}



/**
 * @member {Number} id
 */
Catering.prototype['id'] = undefined;

/**
 * @member {String} titel
 */
Catering.prototype['titel'] = undefined;

/**
 * @member {String} beschrijving
 */
Catering.prototype['beschrijving'] = undefined;

/**
 * @member {Number} prijsPerPersoon
 */
Catering.prototype['prijsPerPersoon'] = undefined;






export default Catering;

