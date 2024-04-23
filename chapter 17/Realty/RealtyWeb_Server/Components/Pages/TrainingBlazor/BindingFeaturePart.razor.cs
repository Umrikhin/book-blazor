using Microsoft.AspNetCore.Components;

namespace RealtyWeb_Server.Components.Pages.TrainingBlazor
{
    public partial class BindingFeaturePart
    {
        private string selectedPhone = string.Empty;
        Realty_Models.TrainingBlazorModels.Tenant tenant = new Realty_Models.TrainingBlazorModels.Tenant()
        {
            Id = 1,
            Fio = "Иванов Алексей Владимирович",
            Dr = DateTime.Parse("01.12.1980", System.Globalization.CultureInfo.GetCultureInfo("ru")),
            DateContract = DateTime.Parse("10.10.2024", System.Globalization.CultureInfo.GetCultureInfo("ru")),
            Commission = 12000.50d,
            IsSend = true,
            Phones = new List<Realty_Models.TrainingBlazorModels.Phone>()
            {
                new Realty_Models.TrainingBlazorModels.Phone() { Id = 1, TypePhone = "Мобильный", NumberPhone = "+79184003080" },
                new Realty_Models.TrainingBlazorModels.Phone() { Id = 2, TypePhone = "Домашний", NumberPhone = "2607060" },
                new Realty_Models.TrainingBlazorModels.Phone() { Id = 3, TypePhone = "Рабочий", NumberPhone = "2355050" }
            }
        };
        string Status { get; set; } = "Кнопка еще не нажата!";
        private void ButtonClicked()
        {
            Status = "Кнопку нажата один раз.";
        }
        private void ButtonDoubleClicked()
        {
            Status = "Кнопка нажата дважды.";
        }
        private void ButtonClicked(bool isSingleClick)
        {
            Status = $"Кнопка нажата один раз {isSingleClick}";
        }
        private void ButtonDoubleClicked(string status)
        {
            Status = status;
        }
        void SelectedPhonesChanged(ChangeEventArgs e)
        {
            if (e.Value is not null)
            {
                selectedPhone = (string)e.Value;
            }
        }
    }
}
