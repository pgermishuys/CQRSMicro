﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMicro.Core
{
	public class InMemoryBus : IMessageBus
	{
		private readonly Dictionary<Type, List<IMessageHandler>> handlerLookup = new Dictionary<Type, List<IMessageHandler>>();
		public string Name { get; set; }
		public InMemoryBus(string name)
		{
			this.Name = name;
		}

		public async void PublishMessage<T>(T message) where T : IMessage
		{
			var task = Task.Factory.StartNew(() =>
			{
				DispatchByType(message);	
			});
			await task;
		}

		public void Subscribe<T>(IMessageHandler handler) where T : IMessage
		{
			List<IMessageHandler> handlers;
			var type = typeof(T);
			if (!handlerLookup.TryGetValue(type, out handlers))
			{
				handlerLookup.Add(type, handlers = new List<IMessageHandler>());
			}
			if (!handlers.Any(x => x.Equals(handler)))
			{
				handlers.Add(handler);
			}
		}

		private void DispatchByType(IMessage message)
		{
			var type = message.GetType();
			do
			{
				DispatchByType(message, type);
				type = type.BaseType;
			} while (type != null && type != typeof(IMessage));
		}

		private void DispatchByType(IMessage message, Type type)
		{
			List<IMessageHandler> list;
			if (!handlerLookup.TryGetValue(type, out list)) return;
			foreach (var handler in list)
			{
				handler.Handle(message);
			}
		}
	}
}
