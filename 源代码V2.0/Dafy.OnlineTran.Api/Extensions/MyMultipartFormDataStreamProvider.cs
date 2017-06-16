using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Dafy.OnlineTran.Api
{
    public class MyMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public MyMultipartFormDataStreamProvider(string uploadPath) : base(uploadPath)
        {

        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            var baseName = base.GetLocalFileName(headers);
            if (string.IsNullOrEmpty(headers.ContentDisposition.FileName))
            {
                return baseName;
            }
            string fileName = headers.ContentDisposition.FileName;
            if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
            {
                fileName = fileName.Trim('"');
            }
            if (fileName.Contains(@"/") || fileName.Contains(@"\"))
            {
                fileName = Path.GetFileName(fileName);
            }
            return Path.Combine(RootPath, string.Format("{0}{1}", baseName, Path.GetExtension(fileName)));
        }
    }
}