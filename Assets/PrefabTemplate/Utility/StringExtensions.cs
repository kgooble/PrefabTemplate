namespace PrefabTemplate.Utility {
  public static class StringExtensions {
    private const string DELIMITER = "/";
    private static readonly int DELIMITER_LENGTH = DELIMITER.Length;

    public static string GetFileExtension(this string path) {
      int dotIndex = path.LastIndexOf(".");
      return path.Substring(dotIndex, path.Length - dotIndex);
    }

    public static string GetFileName(this string path) {
      int index = path.LastIndexOf(DELIMITER);
      return path.Substring(index + DELIMITER_LENGTH, path.Length - index - DELIMITER_LENGTH);
    }

    public static string GetRelativePath(this string path, string subdirectory) {
      int index = path.IndexOf(subdirectory);
      return path.Substring(index, path.Length - index);
    }
  }
}
