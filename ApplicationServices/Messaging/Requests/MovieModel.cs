namespace MC.ApplicationServices.Messaging.Requests
{
    // <summary>
    // Create movie model.
    // </summary>
    public class MovieModel
    {
        // <summary>
        // Gets or sets movie title model
        // </summary>
        required public string Title { get; set; }

        // <summary>
        // Gets or sets movie description.
        // </summary>
        public string? Description { get; set; }

        // <summary>
        // Gets or sets movie release date.
        // </summary>
        public DateTime? ReleaseDate { get; set; }
    }
}
