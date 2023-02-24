/*
 * ThePlaceToMeet.WebApi
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using Org.OpenAPITools.Client;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Model;

namespace Org.OpenAPITools.Test
{
    /// <summary>
    ///  Class for testing MeetingRoomApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class MeetingRoomApiTests
    {
        private MeetingRoomApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new MeetingRoomApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of MeetingRoomApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOf' MeetingRoomApi
            //Assert.IsInstanceOf(typeof(MeetingRoomApi), instance);
        }

        
        /// <summary>
        /// Test MeetingRoomGetById
        /// </summary>
        [Test]
        public void MeetingRoomGetByIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int id = null;
            //var response = instance.MeetingRoomGetById(id);
            //Assert.IsInstanceOf(typeof(Vergaderruimte), response, "response is Vergaderruimte");
        }
        
        /// <summary>
        /// Test MeetingRoomGetByMaxAantalPersonen
        /// </summary>
        [Test]
        public void MeetingRoomGetByMaxAantalPersonenTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int maxAantalPersonen = null;
            //var response = instance.MeetingRoomGetByMaxAantalPersonen(maxAantalPersonen);
            //Assert.IsInstanceOf(typeof(List<Vergaderruimte>), response, "response is List<Vergaderruimte>");
        }
        
        /// <summary>
        /// Test MeetingRoomMeetingRooms
        /// </summary>
        [Test]
        public void MeetingRoomMeetingRoomsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.MeetingRoomMeetingRooms();
            //Assert.IsInstanceOf(typeof(List<Vergaderruimte>), response, "response is List<Vergaderruimte>");
        }
        
    }

}