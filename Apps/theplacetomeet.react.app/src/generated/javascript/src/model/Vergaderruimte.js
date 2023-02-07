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
import Reservatie from './Reservatie';
import VergaderruimteType from './VergaderruimteType';

/**
 * The Vergaderruimte model module.
 * @module model/Vergaderruimte
 * @version 1.0
 */
class Vergaderruimte {
    /**
     * Constructs a new <code>Vergaderruimte</code>.
     * @alias module:model/Vergaderruimte
     */
    constructor() { 
        
        Vergaderruimte.initialize(this);
    }

    /**
     * Initializes the fields of this object.
     * This method is used by the constructors of any subclasses, in order to implement multiple inheritance (mix-ins).
     * Only for internal use.
     */
    static initialize(obj) { 
    }

    /**
     * Constructs a <code>Vergaderruimte</code> from a plain JavaScript object, optionally creating a new instance.
     * Copies all relevant properties from <code>data</code> to <code>obj</code> if supplied or a new instance if not.
     * @param {Object} data The plain JavaScript object bearing properties of interest.
     * @param {module:model/Vergaderruimte} obj Optional instance to populate.
     * @return {module:model/Vergaderruimte} The populated <code>Vergaderruimte</code> instance.
     */
    static constructFromObject(data, obj) {
        if (data) {
            obj = obj || new Vergaderruimte();

            if (data.hasOwnProperty('id')) {
                obj['id'] = ApiClient.convertToType(data['id'], 'Number');
            }
            if (data.hasOwnProperty('naam')) {
                obj['naam'] = ApiClient.convertToType(data['naam'], 'String');
            }
            if (data.hasOwnProperty('vergaderruimteType')) {
                obj['vergaderruimteType'] = VergaderruimteType.constructFromObject(data['vergaderruimteType']);
            }
            if (data.hasOwnProperty('maximumAantalPersonen')) {
                obj['maximumAantalPersonen'] = ApiClient.convertToType(data['maximumAantalPersonen'], 'Number');
            }
            if (data.hasOwnProperty('prijsPerUur')) {
                obj['prijsPerUur'] = ApiClient.convertToType(data['prijsPerUur'], 'Number');
            }
            if (data.hasOwnProperty('prijsPerPersoonStandaardCatering')) {
                obj['prijsPerPersoonStandaardCatering'] = ApiClient.convertToType(data['prijsPerPersoonStandaardCatering'], 'Number');
            }
            if (data.hasOwnProperty('reservaties')) {
                obj['reservaties'] = ApiClient.convertToType(data['reservaties'], [Reservatie]);
            }
        }
        return obj;
    }

    /**
     * Validates the JSON data with respect to <code>Vergaderruimte</code>.
     * @param {Object} data The plain JavaScript object bearing properties of interest.
     * @return {boolean} to indicate whether the JSON data is valid with respect to <code>Vergaderruimte</code>.
     */
    static validateJSON(data) {
        // ensure the json data is a string
        if (data['naam'] && !(typeof data['naam'] === 'string' || data['naam'] instanceof String)) {
            throw new Error("Expected the field `naam` to be a primitive type in the JSON string but got " + data['naam']);
        }
        if (data['reservaties']) { // data not null
            // ensure the json data is an array
            if (!Array.isArray(data['reservaties'])) {
                throw new Error("Expected the field `reservaties` to be an array in the JSON data but got " + data['reservaties']);
            }
            // validate the optional field `reservaties` (array)
            for (const item of data['reservaties']) {
                Reservatie.validateJsonObject(item);
            };
        }

        return true;
    }


}



/**
 * @member {Number} id
 */
Vergaderruimte.prototype['id'] = undefined;

/**
 * @member {String} naam
 */
Vergaderruimte.prototype['naam'] = undefined;

/**
 * @member {module:model/VergaderruimteType} vergaderruimteType
 */
Vergaderruimte.prototype['vergaderruimteType'] = undefined;

/**
 * @member {Number} maximumAantalPersonen
 */
Vergaderruimte.prototype['maximumAantalPersonen'] = undefined;

/**
 * @member {Number} prijsPerUur
 */
Vergaderruimte.prototype['prijsPerUur'] = undefined;

/**
 * @member {Number} prijsPerPersoonStandaardCatering
 */
Vergaderruimte.prototype['prijsPerPersoonStandaardCatering'] = undefined;

/**
 * @member {Array.<module:model/Reservatie>} reservaties
 */
Vergaderruimte.prototype['reservaties'] = undefined;






export default Vergaderruimte;

