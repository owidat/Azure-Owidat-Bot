using System;
using Microsoft.Bot.Builder.FormFlow;

public enum CarOptions { Convertible = 1, SUV, EV };
//public enum CarOptions_AR { Convertible = "سيارة مكشوفة", SUV = "الدفع الرباعي", EV = "كهربائية" };
public enum ColorOptions { Red = 1, White, Blue };

// For more information about this template visit http://aka.ms/azurebots-csharp-form
[Serializable]
public class BasicForm
{
    [Prompt("مرحباً، ما هو اسمك لو تكرمت")]
    public string Name { get; set; }

    [Prompt("ما هو نوع سيارتك المفضلة؟ {||}")]
    public CarOptions Car { get; set; }

    [Prompt("ما هو اللون المفضل لسيارتك {||}")]
    public ColorOptions Color { get; set; }

    public static IForm<BasicForm> BuildForm()
    {
        // Builds an IForm<T> based on BasicForm
        return new FormBuilder<BasicForm>().Build();
    }

    public static IFormDialog<BasicForm> BuildFormDialog(FormOptions options = FormOptions.PromptInStart)
    {
        // Generated a new FormDialog<T> based on IForm<BasicForm>
        return FormDialog.FromForm(BuildForm, options);
    }
}
