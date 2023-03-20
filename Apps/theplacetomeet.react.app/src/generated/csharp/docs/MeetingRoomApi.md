# Org.OpenAPITools.Api.MeetingRoomApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**MeetingRoomGetById**](MeetingRoomApi.md#meetingroomgetbyid) | **GET** /MeetingRoom/{id} | 
[**MeetingRoomGetByMaxAantalPersonen**](MeetingRoomApi.md#meetingroomgetbymaxaantalpersonen) | **GET** /MeetingRoom/max/{maxAantalPersonen} | 
[**MeetingRoomMeetingRooms**](MeetingRoomApi.md#meetingroommeetingrooms) | **GET** /MeetingRoom | 



## MeetingRoomGetById

> MeetingRoom MeetingRoomGetById (int id)



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class MeetingRoomGetByIdExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new MeetingRoomApi(Configuration.Default);
            var id = 56;  // int | 

            try
            {
                MeetingRoom result = apiInstance.MeetingRoomGetById(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling MeetingRoomApi.MeetingRoomGetById: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int**|  | 

### Return type

[**MeetingRoom**](MeetingRoom.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## MeetingRoomGetByMaxAantalPersonen

> List&lt;MeetingRoom&gt; MeetingRoomGetByMaxAantalPersonen (string maxAantalPersonen, int? maaxNumberOfPersons = null)



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class MeetingRoomGetByMaxAantalPersonenExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new MeetingRoomApi(Configuration.Default);
            var maxAantalPersonen = "maxAantalPersonen_example";  // string | 
            var maaxNumberOfPersons = 56;  // int? |  (optional) 

            try
            {
                List<MeetingRoom> result = apiInstance.MeetingRoomGetByMaxAantalPersonen(maxAantalPersonen, maaxNumberOfPersons);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling MeetingRoomApi.MeetingRoomGetByMaxAantalPersonen: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **maxAantalPersonen** | **string**|  | 
 **maaxNumberOfPersons** | **int?**|  | [optional] 

### Return type

[**List&lt;MeetingRoom&gt;**](MeetingRoom.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## MeetingRoomMeetingRooms

> List&lt;MeetingRoom&gt; MeetingRoomMeetingRooms ()



### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class MeetingRoomMeetingRoomsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new MeetingRoomApi(Configuration.Default);

            try
            {
                List<MeetingRoom> result = apiInstance.MeetingRoomMeetingRooms();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling MeetingRoomApi.MeetingRoomMeetingRooms: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**List&lt;MeetingRoom&gt;**](MeetingRoom.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

