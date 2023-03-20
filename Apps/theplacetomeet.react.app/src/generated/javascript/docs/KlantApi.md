# ThePlaceToMeetWebApi.KlantApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**customerAdd**](KlantApi.md#customerAdd) | **POST** /Klant | 
[**customerCustomers**](KlantApi.md#customerCustomers) | **GET** /Klant | 
[**customerGetByEmail**](KlantApi.md#customerGetByEmail) | **GET** /Klant/{email} | 



## customerAdd

> customerAdd(opts)



### Example

```javascript
import ThePlaceToMeetWebApi from 'the_place_to_meet_web_api';

let apiInstance = new ThePlaceToMeetWebApi.KlantApi();
let opts = {
  'klant': new ThePlaceToMeetWebApi.Klant() // Klant | 
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
 **klant** | [**Klant**](Klant.md)|  | [optional] 

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json


## customerCustomers

> [Klant] customerCustomers()



### Example

```javascript
import ThePlaceToMeetWebApi from 'the_place_to_meet_web_api';

let apiInstance = new ThePlaceToMeetWebApi.KlantApi();
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

[**[Klant]**](Klant.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


## customerGetByEmail

> Klant customerGetByEmail(email)



### Example

```javascript
import ThePlaceToMeetWebApi from 'the_place_to_meet_web_api';

let apiInstance = new ThePlaceToMeetWebApi.KlantApi();
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

[**Klant**](Klant.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

