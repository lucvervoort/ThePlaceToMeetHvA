# ThePlaceToMeetWebApi.CateringApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**cateringCaterings**](CateringApi.md#cateringCaterings) | **GET** /Catering | 
[**cateringGetBy**](CateringApi.md#cateringGetBy) | **GET** /Catering/{id} | 



## cateringCaterings

> [Catering] cateringCaterings()



### Example

```javascript
import ThePlaceToMeetWebApi from 'the_place_to_meet_web_api';

let apiInstance = new ThePlaceToMeetWebApi.CateringApi();
apiInstance.cateringCaterings((error, data, response) => {
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

[**[Catering]**](Catering.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


## cateringGetBy

> Catering cateringGetBy(id)



### Example

```javascript
import ThePlaceToMeetWebApi from 'the_place_to_meet_web_api';

let apiInstance = new ThePlaceToMeetWebApi.CateringApi();
let id = 56; // Number | 
apiInstance.cateringGetBy(id, (error, data, response) => {
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
 **id** | **Number**|  | 

### Return type

[**Catering**](Catering.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

