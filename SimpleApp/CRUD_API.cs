using System;
using System.Threading.Tasks;

namespace SimpleApp
{
    public class CRUD_API
    {
        List<Person> users;

        public CRUD_API(List<Person> users)
        {
            this.users = users;
        }

        public async Task GetAllPeopleAsync(HttpResponse response)
        {
            await response.WriteAsJsonAsync(users);
        }

        public async Task GetPersonAsync(string? id, HttpResponse response, HttpRequest request)
        {
            Person? user = users.FirstOrDefault(x => x.Id == id);

            if (user != null)
            {
                await response.WriteAsJsonAsync(user);
            }
            else
            {
                await NotFoundAsync(response);
            }
        }

        public async Task DeletePersonAsync(string? id, HttpResponse response, HttpRequest request)
        {
            Person? user = users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                users.Remove(user);
                await response.WriteAsJsonAsync(user);
            }
            else
            {
                await NotFoundAsync(response);
            }
        }

        public async Task CreatePersonAsync(HttpResponse response, HttpRequest request)
        {
            try
            {
                var user = await request.ReadFromJsonAsync<Person>();

                if (user != null)
                {
                    user.Id = Guid.NewGuid().ToString();
                    users.Add(user);
                    await response.WriteAsJsonAsync(user);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                await IncorrectedDataAsync(response);
            }
        }

        public async Task UpdatePersonAsync(HttpResponse response, HttpRequest request)
        {
            try
            {
                Person? updatedUser = await request.ReadFromJsonAsync<Person>();
                
                if (updatedUser != null)
                {
                    var user = users.FirstOrDefault(u => u.Id == updatedUser.Id);

                    if (user != null)
                    {
                        user.Age = updatedUser.Age;
                        user.Name = updatedUser.Name;
                        await response.WriteAsJsonAsync(user);
                    }
                    else
                    {
                        await NotFoundAsync(response);
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                await IncorrectedDataAsync(response);
            }
        }

        private async Task IncorrectedDataAsync(HttpResponse response)
        {
            response.StatusCode = 400;
            await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
        }

        private async Task NotFoundAsync(HttpResponse response)
        {
            response.StatusCode = 404;
            await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
        }
    }
}
