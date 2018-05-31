using System;

namespace JobApp.Shared.Services
{
    public class GuidService
    {
        public Guid GenerateNewGuid()
            => Guid.NewGuid();
    }
}
