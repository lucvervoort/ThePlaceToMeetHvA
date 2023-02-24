import ClientBaseClass from "./ClientBaseClass";

export default class Customer extends ClientBaseClass {
	/**
	 * undefined
	 * @param {{status200: function(string), status404: function(string), error: function(error), else: function(integer, string)}} responseHandler
	 */
	Customers(responseHandler) {
		responseHandler = this.generateResponseHandler(responseHandler);

		const url = '/Klant';

		// noinspection Duplicates
		this.executeApiCall(url, 'get')
			.then(response => {
				switch (response.status) {
				case 200:
					if (responseHandler.status200) {
						response.text()
							.then(responseText => {
								responseHandler.status200(responseText);
							})
							.catch(responseHandler.error);
						return;
					}
					break;
				case 404:
					if (responseHandler.status404) {
						response.text()
							.then(responseText => {
								responseHandler.status404(responseText);
							})
							.catch(responseHandler.error);
						return;
					}
					break;
				}

				// If we are here, we basically have a response statusCode that we were npt expecting or are not set to handle
				// Go ahead and fall back to the catch-all
				this.handleUnhandledResponse(response, responseHandler);
			})
			.catch(error => {
				responseHandler.error(error);
			});
	}

	/**
	 * undefined
	 * @param {{status200: function(string), status400: function(string), error: function(error), else: function(integer, string)}} responseHandler
	 */
	Add(responseHandler) {
		responseHandler = this.generateResponseHandler(responseHandler);

		const url = '/Klant';

		// noinspection Duplicates
		this.executeApiCall(url, 'post')
			.then(response => {
				switch (response.status) {
				case 200:
					if (responseHandler.status200) {
						response.text()
							.then(responseText => {
								responseHandler.status200(responseText);
							})
							.catch(responseHandler.error);
						return;
					}
					break;
				case 400:
					if (responseHandler.status400) {
						response.text()
							.then(responseText => {
								responseHandler.status400(responseText);
							})
							.catch(responseHandler.error);
						return;
					}
					break;
				}

				// If we are here, we basically have a response statusCode that we were npt expecting or are not set to handle
				// Go ahead and fall back to the catch-all
				this.handleUnhandledResponse(response, responseHandler);
			})
			.catch(error => {
				responseHandler.error(error);
			});
	}

	/**
	 * undefined
	 * @param {string} email
	 * @param {{status200: function(string), status404: function(string), error: function(error), else: function(integer, string)}} responseHandler
	 */
	GetByEmail(email, responseHandler) {
		responseHandler = this.generateResponseHandler(responseHandler);

		const url = '/Klant/' +
			(email ? encodeURI(email) : '');

		// noinspection Duplicates
		this.executeApiCall(url, 'get')
			.then(response => {
				switch (response.status) {
				case 200:
					if (responseHandler.status200) {
						response.text()
							.then(responseText => {
								responseHandler.status200(responseText);
							})
							.catch(responseHandler.error);
						return;
					}
					break;
				case 404:
					if (responseHandler.status404) {
						response.text()
							.then(responseText => {
								responseHandler.status404(responseText);
							})
							.catch(responseHandler.error);
						return;
					}
					break;
				}

				// If we are here, we basically have a response statusCode that we were npt expecting or are not set to handle
				// Go ahead and fall back to the catch-all
				this.handleUnhandledResponse(response, responseHandler);
			})
			.catch(error => {
				responseHandler.error(error);
			});
	}

}
