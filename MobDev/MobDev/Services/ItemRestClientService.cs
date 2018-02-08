using System;
using System.Collections.Generic;
using System.Text;
using MobDev.Models;
using System.Threading.Tasks;

namespace MobDev.Services
{
    public class ItemRestClientService
    {

        public async Task<List<ItemsData>> PostCharForPostClient(ItemsFromAPI req)
        {

            RestClient<ItemsData> restClient = new RestClient<ItemsData>();

            var ItemList = await restClient.PostAsync(req);

            return ItemList;
        }
    }
}
