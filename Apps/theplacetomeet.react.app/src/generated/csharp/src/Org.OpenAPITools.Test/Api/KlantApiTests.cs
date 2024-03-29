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
    ///  Class for testing KlantApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class KlantApiTests
    {
        private KlantApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new KlantApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of KlantApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOf' KlantApi
            //Assert.IsInstanceOf(typeof(KlantApi), instance);
        }

        
        /// <summary>
        /// Test CustomerAdd
        /// </summary>
        [Test]
        public void CustomerAddTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Klant klant = null;
            //instance.CustomerAdd(klant);
            
        }
        
        /// <summary>
        /// Test CustomerCustomers
        /// </summary>
        [Test]
        public void CustomerCustomersTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.CustomerCustomers();
            //Assert.IsInstanceOf(typeof(List<Klant>), response, "response is List<Klant>");
        }
        
        /// <summary>
        /// Test CustomerGetByEmail
        /// </summary>
        [Test]
        public void CustomerGetByEmailTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string email = null;
            //var response = instance.CustomerGetByEmail(email);
            //Assert.IsInstanceOf(typeof(Klant), response, "response is Klant");
        }
        
    }

}
