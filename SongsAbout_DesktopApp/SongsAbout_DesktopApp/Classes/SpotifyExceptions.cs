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
        private const string defMsg = "An unknown error involving the Spotify API has occurred";
        public override string Message
        {
            get { return this.GetType().ToString() + ": " + base.Message; }
        }
        //  public Error Error { get; set; }
        public List<Error> Errors { get; set; }
        public int ErrorNum { get { return Errors.Count; } }
        public SpotifyException(string msg = defMsg) : base(msg)
        {
            this.Errors = new List<Error>();
        }
        public SpotifyException(Error err, string msg = defMsg) : base(msg)
        {
            this.Errors = new List<Error>();
            this.Errors.Add(err);
        }
        public SpotifyException(List<Error> errors, string msg = defMsg) : base(msg)
        {
            this.Errors = new List<Error>();
            this.Errors = errors;
        }


    }

    public class UnassignedAPIException : SpotifyException
    {
        private const string defMsg = "The API has not yet been called.";
        public override string Message
        {
            get { return "API not yet defined: " + base.Message; }
        }

        public UnassignedAPIException(string msg = defMsg) : base(msg)
        {
        }
        public UnassignedAPIException(Error err, string msg = defMsg) : base(err, msg)
        {
        }
        public UnassignedAPIException(List<Error> errors, string msg = defMsg) : base(errors, msg)
        {
        }
    }

    public class ProfileAssignmentError : SpotifyException
    {
        private const string defMsg = "An error has occured assigning the user profile.";
        public override string Message
        {
            get { return "Error Assigning Profile: " + base.Message; }
        }
        public ProfileAssignmentError(string msg = defMsg) : base(msg)
        {

        }
        public ProfileAssignmentError(Error err, string msg = defMsg) : base(err, msg)
        {
        }
        public ProfileAssignmentError(List<Error> errors, string msg = defMsg) : base(errors, msg)
        {
        }
    }
    public class SpotifyAuthError : SpotifyException
    {
        private const string defMsg = "An error has occured assigning the user profile.";
        public AutorizationCodeAuthResponse AuthResponse { get; set; }
        public override string Message
        {
            get { return "Error Assigning Profile: " + base.Message; }
        }
        public SpotifyAuthError(string msg = defMsg) : base(msg)
        {
        }
        public SpotifyAuthError(Error err, string msg = defMsg) : base(err, msg)
        {
        }
        public SpotifyAuthError(List<Error> errors, string msg = defMsg) : base(errors, msg)
        {
        }
        public SpotifyAuthError(AutorizationCodeAuthResponse response, List<Error> errors, string msg = defMsg) : base(errors, msg)
        {
            this.AuthResponse = response;
        }
    }

    public class SpotifyImportError<SpotifyT> : SpotifyException
    {
        private const string defMsg = "Spotify entity not imported correctly.";
        public override string Message
        {
            get { return "Error Importing: " + typeof(SpotifyT) + " from the API: " + base.Message; }
        }
        public SpotifyImportError(string msg = defMsg) : base(msg)
        {
        }
        public SpotifyImportError(Error err, string msg = defMsg) : base(err, msg)
        {
        }
        public SpotifyImportError(List<Error> errors, string msg = defMsg) : base(errors, msg)
        {
        }

    }

    public class SpotifyImageImportError : SpotifyImportError<SpotifyAPI.Web.Models.Image>
    {
        private const string defMsg = "Unknown image import error.";

        public SpotifyImageImportError(string msg = defMsg) : base(msg)
        {
        }
        public SpotifyImageImportError(Error err, string msg = defMsg) : base(err, msg)
        {
        }
        public SpotifyImageImportError(List<Error> errors, string msg = defMsg) : base(errors, msg)
        {
        }
    }

}
