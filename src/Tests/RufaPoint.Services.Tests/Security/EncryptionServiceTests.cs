﻿using RufaPoint.Core.Domain.Security;
using RufaPoint.Services.Security;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Services.Tests.Security
{

    public class EncryptionServiceTests : ServiceTest
    {
        private IEncryptionService _encryptionService;
        private SecuritySettings _securitySettings;

        public EncryptionServiceTests() 
        {
            _securitySettings = new SecuritySettings
            {
                EncryptionKey = "273ece6f97dd844d"
            };
            _encryptionService = new EncryptionService(_securitySettings);
        }

        [Fact]
        public void Can_hash_sha1()
        {
            var password = "MyLittleSecret";
            var saltKey = "salt1";
            var hashedPassword = _encryptionService.CreatePasswordHash(password, saltKey, "SHA1");
            hashedPassword.ShouldEqual("A07A9638CCE93E48E3F26B37EF7BDF979B8124D6");
        }

        [Fact]
        public void Can_hash_sha512() 
        {
            var password = "MyLittleSecret";
            var saltKey = "salt1";
            var hashedPassword = _encryptionService.CreatePasswordHash(password, saltKey, "SHA512");
            hashedPassword.ShouldEqual("4506D65FDB6F3A8CF97278AB7C5C62DEC35EADD474BE1E6243776691D56E1B27F71C1D9085B26BD7513BED89822204D6B8FCBD6E665D46558C48F56D21B2A293");
        }

        [Fact]
        public void Can_encrypt_and_decrypt() 
        {
            var password = "MyLittleSecret";
            var encryptedPassword = _encryptionService.EncryptText(password);
            var decryptedPassword = _encryptionService.DecryptText(encryptedPassword);
            decryptedPassword.ShouldEqual(password);
        }
    }
}
