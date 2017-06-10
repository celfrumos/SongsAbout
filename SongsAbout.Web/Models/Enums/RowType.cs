namespace SongsAbout.Web.Models
{
    public enum RowStyle
    {
        SquareImage,
        InlineImage,
        TextOnly
    }

    public class RowDetails
    {
        public bool AllowEdit { get; set; } = false;
        public RowStyle RowStyle { get; set; } = RowStyle.SquareImage;
    }

}