/**
 * This is middleware for ALL client API webservice calls.
 * This file is designed to be altered.
 */
export default class ClientMiddleware {
	/**
	 * The root Endpoint URL for all webservice method calls in this Client.
	 * This is designed to be altered.
	 * @return {string}
	 */
	static getEndpointUrl() {
		return 'https://localhost:7045';
	}

	/**
	 * The default/initial requestOptions to be sent to any fetch() call.
	 * This is designed to be altered.
	 * @param {string} method
	 * @return {object}
	 */
	static generateRequestOptionsForMethod(method) {
		const requestOptions = {
			method: method,
			credentials: 'same-origin',
			headers: new Headers(),
		};

		return requestOptions;
	}

	/**
	 * This method is called on EVERY API call.
	 * Feel free to modify, or you can remove this method altogether if an onApiCall handler is not needed.
	 *
	 * @method onApiCall
	 * @param {string} url
	 * @param {string} method
	 * @param [request]
	 * @param {string} [requestType]
	 */
	// eslint-disable-next-line no-unused-vars
	static onApiCall(url, method, request, requestType) {
		console.log('[API Call] ' + method.toUpperCase() + ' ' + url);
	}

	/**
	 * This method is called on EVERY API response.
	 * Feel free to modify, or you can remove this method altogether if an onApiResponse handler is not needed.
	 *
	 * @method onApiResponse
	 * @param {string} url
	 * @param {string} method
	 * @param [request]
	 * @param {string} [requestType]
	 */
	// eslint-disable-next-line no-unused-vars
	static onApiResponse(url, method, request, requestType) {
		console.log('[API Response] ' + method.toUpperCase() + ' ' + url);
	}

	/**
	 * The default/initial set of response handlers for the response to any fetch() call.
	 * This is designed to be altered.
	 * @return {object}
	 */
	static generateDefaultResponseHandler() {
		const responseHandler = {
			error: error => {
				console.error(error);
			},
			else: (statusCode, responseText) => {
				console.warn('Unhandled API Call response: HTTP Status Code [' + statusCode + ']: [' + responseText + ']');
			}
		};

		return responseHandler;
	}
}
