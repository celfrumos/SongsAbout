using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpotifyAPI.Web.Models;
using SpotifyAPI;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using System.Threading.Tasks;

namespace SongsAbout_DesktopApp.Classes
{
    public class SpotifyException : SpotifyWebApiException
    {
        private const string defMsg = "An unknown Spotify Error has occurred";
        public override string Message
        {
            get { return $"SpotifyException: {GetType()}: {base.Message}"; }
        }

        public SpotifyException(string msg = defMsg) : base(msg)
        {
            Console.WriteLine(Message);
        }
    }

    public class UnassignedAPIException : SpotifyException
    {
        private const string defMsg = "The API has not yet been called.";
        public override string Message
        {
            get { return $"API not yet defined: {base.Message}"; }
        }

        public UnassignedAPIException(string msg = defMsg) : base(msg)
        {
        }

    }

    public class ProfileAssignmentError : SpotifyException
    {
        private const string defMsg = "An error has occured assigning the user profile.";
        public override string Message
        {
            get { return $"Error Assigning Profile: {base.Message}"; }
        }
        public ProfileAssignmentError(string msg = defMsg) : base(msg)
        {

        }
    }

    public class SpotifyAuthError : SpotifyException
    {
        private const string defMsg = "An error has occured assigning the user profile.";
        public AutorizationCodeAuthResponse AuthResponse { get; set; }

        public override string Message
        {
            get { return $"Error Assigning Profile: {base.Message}"; }
        }
        public SpotifyAuthError(string msg = defMsg) : base(msg)
        {
        }

    }
    public class SpotifyImportError : SpotifyException
    {
        private const string defMsg = "Spotify entity not imported correctly.";
        public override string Message
        {
            get { return $"Error importing from the API: {base.Message}"; }
        }
        public SpotifyImportError(string msg = defMsg) : base(msg)
        {
        }
    }
    public class SpotifyImportError<SpotifyType> : SpotifyImportError
    {
        private const string defMsg = "Spotify entity not imported correctly.";
        public override string Message
        {
            get { return $"Error Importing: {typeof(SpotifyType)} from the API: {base.Message}"; }
        }
        public SpotifyImportError(string msg = defMsg) : base(msg)
        {
        }
    }

    public class SpotifyConversionError : SpotifyException
    {
        private const string defMsg = "Spotify Conversion Error.";

        public Type FromType { get; set; }
        public Type ToType { get; set; }

        public override string Message
        {
            get { return $"Error converting {FromType} to {ToType}: {base.Message}"; }
        }

        public SpotifyConversionError(Type fromType, Type toType, string msg = defMsg) : base(msg)
        {
            this.FromType = fromType;
            this.ToType = toType;
        }

    }

    public class SpotifyImageImportError : SpotifyImportError<SpotifyAPI.Web.Models.Image>
    {
        private const string defMsg = "Unknown image import error.";

        public override string Message
        {
            get { return $"Spotify Image Import Error: {base.Message}"; }
        }

        public SpotifyImageImportError(string msg = defMsg) : base(msg)
        {
        }

    }
    public class SpotifyUndefinedAPIError : SpotifyException
    {
        private const string defMsg = "Spotify API not yet defined";

        public override string Message
        {
            get { return $"Spotify API Undefined: {base.Message}"; }
        }

        public SpotifyUndefinedAPIError(string msg = defMsg) : base(msg)
        {
        }
    }

    public class SpotifyUndefinedProfileError : SpotifyException
    {
        private const string defMsg = "Spotify User Profile not yet defined";

        public override string Message
        {
            get { return $"Spotify Profile Undefined: {base.Message}"; }
        }

        public SpotifyUndefinedProfileError(string msg = defMsg) : base(msg)
        {
        }
    }
}
