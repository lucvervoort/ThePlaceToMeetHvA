# ThePlaceToMeetWebApi.CustomerApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**customerAdd**](CustomerApi.md#customerAdd) | **POST** /Customer | 
[**customerCustomers**](CustomerApi.md#customerCustomers) | **GET** /Customer | 
[**customerGetByEmail**](CustomerApi.md#customerGetByEmail) | **GET** /Customer/{email} | 



## customerAdd

> customerAdd(opts)



### Example

```javascript
import ThePlaceToMeetWebApi from 'the_place_to_meet_web_api';

let apiInstance = new ThePlaceToMeetWebApi.CustomerApi();
let opts = {
  'customer': new ThePlaceToMeetWebApi.Customer() // Customer | 
};
apiInstance.customerAdd(opts, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
});
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **customer** | [**Customer**](Customer.md)|  | [optional] 

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json


## customerCustomers

> [Customer] customerCustomers()



### Example

```javascript
import ThePlaceToMeetWebApi from 'the_place_to_meet_web_api';

let apiInstance = new ThePlaceToMeetWebApi.CustomerApi();
apiInstance.customerCustomers((error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**[Customer]**](Customer.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


## customerGetByEmail

> Customer customerGetByEmail(email)



### Example

```javascript
import ThePlaceToMeetWebApi from 'the_place_to_meet_web_api';

let apiInstance = new ThePlaceToMeetWebApi.CustomerApi();
let email = "email_example"; // String | 
apiInstance.customerGetByEmail(email, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **email** | **String**|  | 

### Return type

[**Customer**](Customer.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

