using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_UI
{
   
        /// <summary>
        /// Вспомогательный класс.
        /// </summary>
        public static class MessageShowUi
        {
            /// <summary>
            /// Создание диалогового окна.
            /// </summary>
            /// <param name="message">Передаваемое сообщение.</param>
            private static void ShowDialog(string message)
            {
                var mess = new MessageUi();
                mess.blockText.Text = message;
                mess.Show();
            }

            /// <summary>
            /// Диалог : Покупатель не найден.
            /// </summary>
            public static void ShowNoneCustomer()
            {
                ShowDialog("Покупатель не найден!");
            }

            public static void ShowPhoneIsInDatabase()
            {
                ShowDialog("Этот номер телефона уже существует в базе!");
            }


            public static void ShowNoneSearch()
            {
                ShowDialog("Неверно задан критерий поиска!");
            }

            public static void ShowNoneName()
            {
                ShowDialog("Введите имя.");
            }

            public static void ShowNoneTelefon()
            {
                ShowDialog("Не верно введен телефон!");
            }

            public static void ShowNoneDateOfBirdth()
            {
                ShowDialog("День рождения введите в формате ДД.ММ.ГГ");
            }

            public static void ShowSave()
            {
                ShowDialog("Сохранение успешно!");
            }

            public static void ShowSaleVisit()
            {
                ShowDialog("Введите сумму чека визита");
            }

            public static void ShowNonePole()
            {
                ShowDialog("Поле заполнено не верно.");
            }

            public static void ShowKart()
            {
                ShowDialog("Клиенту нужно выдать карту.");
            }
             public static void GiveOutCard()
             {
                ShowDialog("");

             }
            
            public static void UserNone()
            {
                ShowDialog("Пользователь не найден.");
            }

            public static void PassFalse()
            {
                ShowDialog("Пароль не верен.");
            }



        }
}

