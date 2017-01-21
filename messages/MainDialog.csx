#load "BasicForm.csx"

using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;

/// This dialog is the main bot dialog, which will call the Form Dialog and handle the results
[Serializable]
public class MainDialog : IDialog<BasicForm>
{
    public MainDialog()
    {
    }

    public Task StartAsync(IDialogContext context)
    {
        context.Wait(MessageReceivedAsync);
        return Task.CompletedTask;
    }

    public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
    {
        var message = await argument;
        context.Call(BasicForm.BuildFormDialog(FormOptions.PromptInStart), FormComplete);
    }

    private async Task FormComplete(IDialogContext context, IAwaitable<BasicForm> result)
    {
        try
        {
            var form = await result;
            if (form != null)
            {
                await context.PostAsync("شكراً لك على استكما هذه المعلومات :)");
            }
            else
            {
                await context.PostAsync("معلومات غير مكتملة. الرجاء إعادة المحاولة بكتابة أي رد.");
            }
        }
        catch (OperationCanceledException)
        {
            await context.PostAsync("تم إلغاء الطلبات. الرجاء كتابة أي رد لإعادة المحاولة.");
        }

        context.Wait(MessageReceivedAsync);
    }
}