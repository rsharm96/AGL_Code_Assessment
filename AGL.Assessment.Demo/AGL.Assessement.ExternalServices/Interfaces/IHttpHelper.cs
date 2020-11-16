using System;
using System.Collections.Generic;
using System.Text;

namespace AGL.Assessment.ExternalServices.Interfaces
{
    public interface IHttpHelper<T>
    {
        List<T> GetContentFromURL(string url);
    }
}
