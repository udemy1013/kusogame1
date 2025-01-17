using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Core;
using Unity.Services.Core.Configuration.Internal;
using Unity.Services.Leaderboards.Exceptions;
using Unity.Services.Leaderboards.Internal.Apis.Leaderboards;
using Unity.Services.Leaderboards.Internal.Leaderboards;
using Unity.Services.Leaderboards.Internal.Models;

namespace Unity.Services.Leaderboards.Internal
{
    interface ILeaderboardsApiClientInternal
    {
        Task<Response<LeaderboardEntry>> AddPlayerScoreAsync(string leaderboardId, double score, object metadata = null, string versionId = default);
        Task<Response<LeaderboardScores>> GetPlayerRangeAsync(string leaderboardId,
            int? rangeLimit = null, bool? includeMetadata = false);
        Task<Response<LeaderboardEntry>> GetPlayerScoreAsync(string leaderboardId, bool? includeMetadata = false);
        Task<Response<LeaderboardScoresWithNotFoundPlayerIds>> GetScoresByPlayerIdsAsync(string leaderboardId,
            List<string> playerIds, bool? includeMetadata = false);
        Task<Response<LeaderboardScoresPage>> GetScoresAsync(string leaderboardId, int? offset = null, int? limit = null, bool? includeMetadata = false);
        Task<Response<LeaderboardTierScoresPage>> GetScoresByTierAsync(string leaderboardId, string tierId,
            int? offset = null, int? limit = null, bool? includeMetadata = false);
        Task<Response<LeaderboardVersionEntry>> GetVersionPlayerScoreAsync(string leaderboardId, string versionId, bool? includeMetadata = false);
        Task<Response<LeaderboardVersionScores>> GetVersionPlayerRangeAsync(string leaderboardId, string versionId,
            int? rangeLimit = null, bool? includeMetadata = false);
        Task<Response<LeaderboardVersionScoresPage>> GetVersionScoresAsync(string leaderboardId,
            string versionId, int? offset = null, int? limit = null, bool? includeMetadata = false);
        Task<Response<LeaderboardVersionScoresWithNotFoundPlayerIds>> GetVersionScoresByPlayerIdsAsync(string leaderboardId,
            string versionId, List<string> playerIds, bool? includeMetadata = false);
        Task<Response<LeaderboardVersionTierScoresPage>> GetVersionScoresByTierAsync(string leaderboardId,
            string versionId,
            string tierId, int? offset = null, int? limit = null, bool? includeMetadata = false);
        Task<Response<LeaderboardVersions>> GetVersionsAsync(string leaderboardId, int? limit = null);
    }

    class LeaderboardsApiClientInternal : ILeaderboardsApiClientInternal
    {
        readonly ICloudProjectId m_CloudProjectId;
        readonly IInternalLeaderboardsApiClient m_LeaderboardsApiClient;
        readonly IAuthentication m_Authentication;

        internal LeaderboardsApiClientInternal(ICloudProjectId cloudProjectId, IAuthentication authentication, IInternalLeaderboardsApiClient internalLeaderboardsClient)
        {
            m_CloudProjectId = cloudProjectId;
            m_LeaderboardsApiClient = internalLeaderboardsClient;
            m_Authentication = authentication;
        }

        public Task<Response<LeaderboardEntry>> AddPlayerScoreAsync(string leaderboardId, double score, object metadata = null, string versionId = default)
        {
            ValidateRequiredDependencies();
            var request = new AddLeaderboardPlayerScoreRequest(
                m_CloudProjectId.GetCloudProjectId(), leaderboardId, m_Authentication.GetPlayerId(),
                new AddLeaderboardScore(score, metadata, versionId));

            return m_LeaderboardsApiClient.AddLeaderboardPlayerScoreAsync(request);
        }

        public Task<Response<LeaderboardScores>> GetPlayerRangeAsync(string leaderboardId,
            int? rangeLimit = null, bool? includeMetadata = false)
        {
            ValidateRequiredDependencies();
            var request = new GetLeaderboardPlayerRangeRequest(
                m_CloudProjectId.GetCloudProjectId(), leaderboardId, m_Authentication.GetPlayerId(), rangeLimit, includeMetadata);

            return m_LeaderboardsApiClient.GetLeaderboardPlayerRangeAsync(request);
        }

        public Task<Response<LeaderboardEntry>> GetPlayerScoreAsync(string leaderboardId, bool? includeMetadata = false)
        {
            ValidateRequiredDependencies();
            var request = new GetLeaderboardPlayerScoreRequest(
                m_CloudProjectId.GetCloudProjectId(), leaderboardId, m_Authentication.GetPlayerId(), includeMetadata);

            return m_LeaderboardsApiClient.GetLeaderboardPlayerScoreAsync(request);
        }

        public Task<Response<LeaderboardScoresWithNotFoundPlayerIds>> GetScoresByPlayerIdsAsync(string leaderboardId, List<string> playerIds, bool? includeMetadata = false)
        {
            ValidateRequiredDependencies();
            var request = new GetLeaderboardScoresByPlayerIdsRequest(
                m_CloudProjectId.GetCloudProjectId(), leaderboardId, new LeaderboardPlayerIds(playerIds), includeMetadata);

            return m_LeaderboardsApiClient.GetLeaderboardScoresByPlayerIdsAsync(request);
        }

        public Task<Response<LeaderboardScoresPage>> GetScoresAsync(string leaderboardId,
            int? offset = null, int? limit = null, bool? includeMetadata = false)
        {
            ValidateRequiredDependencies();
            var request = new GetLeaderboardScoresRequest(m_CloudProjectId.GetCloudProjectId(),
                leaderboardId, offset, limit, includeMetadata);

            return m_LeaderboardsApiClient.GetLeaderboardScoresAsync(request);
        }

        public Task<Response<LeaderboardTierScoresPage>> GetScoresByTierAsync(string leaderboardId,
            string tierId, int? offset = null, int? limit = null, bool? includeMetadata = false)
        {
            ValidateRequiredDependencies();
            var request = new GetLeaderboardScoresByTierRequest(m_CloudProjectId.GetCloudProjectId(),
                leaderboardId, tierId, offset, limit, includeMetadata);

            return m_LeaderboardsApiClient.GetLeaderboardScoresByTierAsync(request);
        }

        public Task<Response<LeaderboardVersionEntry>> GetVersionPlayerScoreAsync(string leaderboardId,
            string versionId, bool? includeMetadata = false)
        {
            ValidateRequiredDependencies();
            var request = new GetLeaderboardVersionPlayerScoreRequest(
                m_CloudProjectId.GetCloudProjectId(), leaderboardId, versionId, m_Authentication.GetPlayerId(), includeMetadata);

            return m_LeaderboardsApiClient.GetLeaderboardVersionPlayerScoreAsync(request);
        }

        public Task<Response<LeaderboardVersionScores>> GetVersionPlayerRangeAsync(string leaderboardId,
            string versionId, int? rangeLimit = null, bool? includeMetadata = false)
        {
            ValidateRequiredDependencies();
            var request = new GetLeaderboardVersionPlayerRangeRequest(
                m_CloudProjectId.GetCloudProjectId(), leaderboardId, versionId, m_Authentication.GetPlayerId(), rangeLimit, includeMetadata);

            return m_LeaderboardsApiClient.GetLeaderboardVersionPlayerRangeAsync(request);
        }

        public Task<Response<LeaderboardVersionScoresPage>> GetVersionScoresAsync(string leaderboardId,
            string versionId, int? offset = null, int? limit = null, bool? includeMetadata = false)
        {
            ValidateRequiredDependencies();
            var request = new GetLeaderboardVersionScoresRequest(
                m_CloudProjectId.GetCloudProjectId(), leaderboardId, versionId, offset, limit, includeMetadata);

            return m_LeaderboardsApiClient.GetLeaderboardVersionScoresAsync(request);
        }

        public Task<Response<LeaderboardVersionScoresWithNotFoundPlayerIds>>
        GetVersionScoresByPlayerIdsAsync(string leaderboardId, string versionId, List<string> playerIds, bool? includeMetadata = false)
        {
            ValidateRequiredDependencies();
            var request = new GetLeaderboardVersionScoresByPlayerIdsRequest(
                m_CloudProjectId.GetCloudProjectId(), leaderboardId, versionId, new LeaderboardPlayerIds(playerIds), includeMetadata);

            return m_LeaderboardsApiClient.GetLeaderboardVersionScoresByPlayerIdsAsync(request);
        }

        public Task<Response<LeaderboardVersionTierScoresPage>> GetVersionScoresByTierAsync(string leaderboardId,
            string versionId, string tierId, int? offset = null, int? limit = null, bool? includeMetadata = false)
        {
            ValidateRequiredDependencies();
            var request = new GetLeaderboardVersionScoresByTierRequest(
                m_CloudProjectId.GetCloudProjectId(), leaderboardId, versionId, tierId, offset, limit, includeMetadata);

            return m_LeaderboardsApiClient.GetLeaderboardVersionScoresByTierAsync(request);
        }

        public Task<Response<LeaderboardVersions>> GetVersionsAsync(string leaderboardId, int? limit = null)
        {
            ValidateRequiredDependencies();
            var request =
                new GetLeaderboardVersionsRequest(m_CloudProjectId.GetCloudProjectId(), leaderboardId, limit);

            return m_LeaderboardsApiClient.GetLeaderboardVersionsAsync(request);
        }

        void ValidateRequiredDependencies()
        {
            if (string.IsNullOrEmpty(m_CloudProjectId.GetCloudProjectId()))
            {
                throw new LeaderboardsException(LeaderboardsExceptionReason.ProjectIdMissing, CommonErrorCodes.Unknown,
                    "Project ID is missing - make sure the project is correctly linked to your game and try again.", null);
            }

            if (string.IsNullOrEmpty(m_Authentication.GetPlayerId()))
            {
                throw new LeaderboardsException(LeaderboardsExceptionReason.PlayerIdMissing, CommonErrorCodes.Unknown,
                    "Player ID is missing - ensure you are signed in through the Authentication SDK and try again.", null);
            }

            if (string.IsNullOrEmpty(m_Authentication.GetAccessToken()))
            {
                throw new LeaderboardsException(LeaderboardsExceptionReason.AccessTokenMissing, CommonErrorCodes.InvalidToken,
                    "Access token is missing - ensure you are signed in through the Authentication SDK and try again.", null);
            }
        }
    }
}
