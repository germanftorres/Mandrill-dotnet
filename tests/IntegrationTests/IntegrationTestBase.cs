﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests
{
  public abstract class IntegrationTestBase
  {
    protected bool IsPaidAccount;

    public static bool Validator(object sender, X509Certificate certificate, X509Chain chain,
      SslPolicyErrors sslPolicyErrors) {
      return true;
    }

    [TestFixtureSetUp]
    public void Init() {
      if (ConfigurationManager.AppSettings["IgnoreInvalidSSLCertificate"] == "True")
        ServicePointManager.ServerCertificateValidationCallback = Validator;

      IsPaidAccount = ConfigurationManager.AppSettings["IsPaidAccount"] == "True";
    }

  }
}