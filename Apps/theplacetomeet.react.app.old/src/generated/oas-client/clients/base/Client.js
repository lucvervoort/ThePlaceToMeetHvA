import Catering from "./Catering";
import Customer from "./Customer";
import MeetingRoom from "./MeetingRoom";

/**
 * Use globally to access any of the API Client Methods for the WebService
 */
export default class Client {
}

/**
 * Use in a responseHandler if you want to ignore a given/specific response
 */
export function ignoreResponse() {
}

Client.Catering = new Catering();
Client.Customer = new Customer();
Client.MeetingRoom = new MeetingRoom();
