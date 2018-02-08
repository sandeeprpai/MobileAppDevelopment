using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MobDev.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(MobDev.Services.MockDataStore))]
namespace MobDev.Services
{
	public class MockDataStore : IDataStore<Item>
	{
		bool isInitialized;
		List<Item> items;

		public async Task<bool> AddItemAsync(Item item)
		{
			await InitializeAsync();

			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(Item item)
		{
			await InitializeAsync();

			var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(Item item)
		{
			await InitializeAsync();

			var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);

			return await Task.FromResult(true);
		}

		public async Task<Item> GetItemAsync(string id)
		{
			await InitializeAsync();

			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
		{
			await InitializeAsync();

			return await Task.FromResult(items);
		}

		public Task<bool> PullLatestAsync()
		{
			return Task.FromResult(true);
		}


		public Task<bool> SyncAsync()
		{
			return Task.FromResult(true);
		}

		public async Task InitializeAsync()
		{
			if (isInitialized)
				return;

			items = new List<Item>();
			var _items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Score", Description="Displays the score of an individual character"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Character", Description="Displays the attributes of one character in the party at a time"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Inventory", Description="Show the contents in one character's inventory"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Monsters", Description="Allows for Viewing of one monster in the fight at a time"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Items", Description="displays the details of an item"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Battle", Description="shows a log of actions completed in battle"},
            };

			foreach (Item item in _items)
			{
				items.Add(item);
			}

			isInitialized = true;
		}
	}
}
