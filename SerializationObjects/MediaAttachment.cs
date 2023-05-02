using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Metadata for a media item
    /// </summary>
    public class MediaAttachment
    {
        /// <summary>
        /// Id of the document section it appears in (use the PageMetadataClient methods to find the sections)
        /// </summary>
        [JsonPropertyName("section_id")]
        public int SectionId { get; set; } = 0;

        /// <summary>
        /// Type of media item (eg: "image", "video")
        /// </summary>
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// Item caption. Expect 2 keys: "html" (containing Html content) and "text" (containing the plain-text caption)
        /// </summary>
        [JsonPropertyName("caption")]
        public Dictionary<string, string>? Caption { get; set; }

        /// <summary>
        /// If true, this image can be displayed in a 'gallery' view.
        /// </summary>
        [JsonPropertyName("showInGallery")]
        public bool ShowInGallery { get; set; }

        /// <summary>
        /// (Only images) Set of sources for this item. Usually a single item, can be more. Expect two keys in the dictionary: "src" (url without scheme!) and "scale" (scale factor with "x" suffixed, eg: "1x")
        /// </summary>
        [JsonPropertyName("srcset")]
        public List<Dictionary<string, string>>? Sources { get; set; }

        /// <summary>
        /// (Only video and audio) List of sources
        /// </summary>
        [JsonPropertyName("sources")]
        public List<MediaAVSourcesMetadata>? AudioVideoSources { get; set; }

        /// <summary>
        /// Titles for the media item in various formats: "canonical", "normalized" and "display".
        /// </summary>
        [JsonPropertyName("titles")]
        public Dictionary<string, string>? Titles { get; set; }

        /// <summary>
        /// Thumbnail image
        /// </summary>
        [JsonPropertyName("thumbnail")]
        public ImageMetadata? Thumbnail { get; set; }

        /// <summary>
        /// Original media item - only for images, otherwise NULL
        /// </summary>
        [JsonPropertyName("original")]
        public ImageMetadata? Original { get; set; }

        /// <summary>
        /// Absolute URL to the MediaWiki page for the object
        /// </summary>
        [JsonPropertyName("file_page")]
        public string? FilePage { get; set; }

        /// <summary>
        /// For audio/video files, the duration in minutes - NULL for other types
        /// </summary>
        [JsonPropertyName("duration")]
        public decimal? Duration { get; set; }

        /// <summary>
        /// Name(s) of the artist. Expect 2 keys: "html" (containing Html content) and "text" (containing the plain-text caption)
        /// </summary>
        [JsonPropertyName("artist")]
        public Dictionary<string, string>? Artist { get; set; }

        /// <summary>
        /// Credits/copyright info. Expect 2 keys: "html" (containing Html content) and "text" (containing the plain-text caption)
        /// </summary>
        [JsonPropertyName("credit")]
        public Dictionary<string, string>? Credits { get; set; }

        /// <summary>
        /// Description. Expect 2 keys: "html" (containing Html content) and "text" (containing the plain-text caption)
        /// </summary>
        [JsonPropertyName("description")]
        public Dictionary<string, string>? Description { get; set; }

        /// <summary>
        /// License information. Expect 3 keys: "type" (type of license), "code" (license code name) and "url" (absolute URI to license name - no "http(s)://" prefix!)
        /// </summary>
        [JsonPropertyName("license")]
        public Dictionary<string, string>? License { get; set; }

        /// <summary>
        /// WB Entity ID (???) - usually populated only for video
        /// </summary>
        [JsonPropertyName("wb_entity_id")]
        public string? WbEntityId { get; set; }

        /// <summary>
        /// Structured information - mostly empty?
        /// </summary>
        [JsonPropertyName("structured")]
        public Dictionary<string, object>? Structured { get; set; }
    }

}
