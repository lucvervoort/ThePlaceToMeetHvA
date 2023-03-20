
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ThePlaceToMeet.IdentityService.Pages.Register;

public class InputModel
{
    [Required]
    [Display(Name= "First name")]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Family name")]
    public string FamilyName { get; set; }

    [Required]
    [Display(Name = "Given name")]

    public string GivenName { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name="Email Address")]
    public string Email { get; set; }

    [Required]
    [Display(Name = "User name")]
    public string UserName { get; set; }

    [Required]
    [PasswordPropertyText]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Required]
    [Url]
    [Display(Name = "Website url")]
    public string WebSite { get; set; }
}