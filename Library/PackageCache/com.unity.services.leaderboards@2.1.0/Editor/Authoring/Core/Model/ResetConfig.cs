using System;

namespace Unity.Services.Leaderboards.Authoring.Core.Model
{
    [Serializable]
    class ResetConfig
    {
        public DateTime Start { get; set; }
        public string Schedule { get; set; }
        public bool Archive { get; set; }
    }
}
