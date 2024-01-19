using Microsoft.AspNetCore.Mvc;

namespace TextFilesMVC;

public class FileController : Controller
{
    private readonly ILogger<FileController> _logger;
    private readonly IWebHostEnvironment _env;

    public FileController(ILogger<FileController> logger, IWebHostEnvironment env)
    {
        _logger = logger;
        _env = env;
    }

    public IActionResult Index()
    {
		var path = Path.Combine(_env.ContentRootPath, "TextFiles");
		ViewBag.Files = Directory.GetFiles(path).Select(Path.GetFileName).ToArray();
        // _logger.LogInformation(path);		
        return View();
    }

	public IActionResult FileContent(string id) {
		var path = Path.Combine(_env.ContentRootPath, "TextFiles", id);
		var content = System.IO.File.ReadAllText(path);
		ViewBag.Content = content;
		return View();
	}
}

