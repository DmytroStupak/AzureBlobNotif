using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBlobNotif
{
    public class Const
    {
        public const string STORAGE_ACCOUNT = "teststoragereenbit";
        public const string KEY = "key";
        public const string CONTAINER = "files";
        public const string CONTAINER_URL = $"https://{Const.STORAGE_ACCOUNT}.blob.core.windows.net/{Const.CONTAINER}/";
    }
}
