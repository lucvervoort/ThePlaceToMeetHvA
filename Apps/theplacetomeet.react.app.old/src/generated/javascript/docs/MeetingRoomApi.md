# ThePlaceToMeetWebApi.MeetingRoomApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**meetingRoomGetById**](MeetingRoomApi.md#meetingRoomGetById) | **GET** /MeetingRoom/{id} | 
[**meetingRoomGetByMaxAantalPersonen**](MeetingRoomApi.md#meetingRoomGetByMaxAantalPersonen) | **GET** /MeetingRoom/max/{maxAantalPersonen} | 
[**meetingRoomMeetingRooms**](MeetingRoomApi.md#meetingRoomMeetingRooms) | **GET** /MeetingRoom | 



## meetingRoomGetById

> MeetingRoom meetingRoomGetById(id)



### Example

```javascript
import ThePlaceToMeetWebApi from 'the_place_to_meet_web_api';

let apiInstance = new ThePlaceToMeetWebApi.MeetingRoomApi();
let id = 56; // Number | 
apiInstance.meetingRoomGetById(id, (error, data, response) => {
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

[**MeetingRoom**](MeetingRoom.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


## meetingRoomGetByMaxAantalPersonen

> [MeetingRoom] meetingRoomGetByMaxAantalPersonen(maxAantalPersonen, opts)



### Example

```javascript
import ThePlaceToMeetWebApi from 'the_place_to_meet_web_api';

let apiInstance = new ThePlaceToMeetWebApi.MeetingRoomApi();
let maxAantalPersonen = "maxAantalPersonen_example"; // String | 
let opts = {
  'maaxNumberOfPersons': 56 // Number | 
};
apiInstance.meetingRoomGetByMaxAantalPersonen(maxAantalPersonen, opts, (error, data, response) => {
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
 **maxAantalPersonen** | **String**|  | 
 **maaxNumberOfPersons** | **Number**|  | [optional] 

### Return type

[**[MeetingRoom]**](MeetingRoom.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


## meetingRoomMeetingRooms

> [MeetingRoom] meetingRoomMeetingRooms()



### Example

```javascript
import ThePlaceToMeetWebApi from 'the_place_to_meet_web_api';

let apiInstance = new ThePlaceToMeetWebApi.MeetingRoomApi();
apiInstance.meetingRoomMeetingRooms((error, data, response) => {
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

[**[MeetingRoom]**](MeetingRoom.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

