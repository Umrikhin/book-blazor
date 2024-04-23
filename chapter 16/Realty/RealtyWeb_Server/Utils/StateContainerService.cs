namespace RealtyWeb_Server.Utils
{
    public class StateContainerService
    {
        /// <summary>
        /// Свойство состояния с начальным значением
        /// </summary>
        public int Value { get; set; } = 0;

        /// <summary>
        /// Событие, которое будет вызвано для изменения состояния
        /// </summary>
        public event Action OnStateChange = null!;

        /// <summary>
        /// Метод, к которому будет обращаться компонент-отправитель
        /// чтобы обновить состояние
        /// </summary>
        public void SetValue(int value)
        {
            Value = value;
            NotifyStateChanged();
        }

        /// <summary>
        /// Уведомление о событии изменения состояния
        /// </summary>
        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
