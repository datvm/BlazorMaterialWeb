namespace BlazorMaterialWeb.Demo.Pages;

partial class Index
{

    bool checkboxChecked = false;
    
    bool chipSelected = true;

    MdDialog diag = null!;
    string dialogReturnValue = "Not yet";
    string diagName = "Your name";
    bool showDialog = false;

    async Task ShowDialogAsync()
    {
        dialogReturnValue = await diag.OpenForResultAsync();
    }

}
