using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace KeySystemBot
{
    internal class Program
    {
		public enum Options
		{
			Register = 1,
			Login = 2,
			License = 3,
			GenerateLicense = 4,
			Deletelicense = 5,
			BlockHWID = 9,
			UnBlockHWID = 10
		}

		private List<long> TrustedUsers = new List<long>();

		private DiscordSocketClient _client;
		static void Main(string[] args)
        {
			new Program().MainAsync().GetAwaiter().GetResult();
		}

		public async Task MainAsync()
		{
			var token = "MTAwNTIyNTEzNjkzMDE2NDc3OA.GgX4JU.qZQvv2XDSy2r7b4gZZiRaIhGpQiORO3WGBRTcQ";
			_client = new DiscordSocketClient();
			_client.MessageReceived += CommandHandler;
			_client.Log += Log;


			await _client.LoginAsync(TokenType.Bot, token);
			await _client.StartAsync();

			await Task.Delay(-1);
		}

		private Task Log(LogMessage msg)
		{
			//Console.WriteLine(((LogMessage)(ref msg)).ToString((StringBuilder)null, true, true, DateTimeKind.Local, (int?)11));
			return Task.CompletedTask;
		}

		private async Task<Task> CommandHandler(SocketMessage message)
		{
			Console.WriteLine("+++LINE: " + (object)message);
			if (message.Content.StartsWith("!deletelicense") && message.Channel.Id == 1005226104761614387)
			{
				LoginSystemV1 loginSystemV = new LoginSystemV1("45.142.115.67");
				string text = message.Content.Replace("!deletelicense ", "");
				loginSystemV.sendPacket(Options.Deletelicense.ToString() + " " + text);
				EmbedBuilder val = new EmbedBuilder();
				val.WithTitle("Key Deleted!");
				val.WithDescription("Key deleted Sucessfully \n KEY: " + text);
				val.WithColor(Color.Red);
				await message.Channel.SendMessageAsync("", false, val.Build(), (RequestOptions)null, (AllowedMentions)null, (MessageReference)null, (MessageComponent)null, (ISticker[])null, (Embed[])null, (MessageFlags)0);
				return Task.CompletedTask;
			}
			if (message.Content.StartsWith("!block") && message.Channel.Id == 1005220070986878976)
			{
				LoginSystemV1 loginSystemV2 = new LoginSystemV1("45.142.115.67");
				string text2 = message.Content.Replace("!block ", "");
				loginSystemV2.sendPacket(Options.BlockHWID.ToString() + " " + text2);
				EmbedBuilder val2 = new EmbedBuilder();
				val2.WithTitle("Block HWID!");
				val2.WithDescription("HWID Blocked Sucessfully \n HWID: " + text2);
				val2.WithColor(Color.Green);
				await message.Channel.SendMessageAsync("", false, val2.Build(), (RequestOptions)null, (AllowedMentions)null, (MessageReference)null, (MessageComponent)null, (ISticker[])null, (Embed[])null, (MessageFlags)0);
				return Task.CompletedTask;
			}
			if (message.Content.StartsWith("!unblock") && message.Channel.Id == 1005220070986878976)
			{
				LoginSystemV1 loginSystemV3 = new LoginSystemV1("45.142.115.67");
				string text3 = message.Content.Replace("!unblock ", "");
				loginSystemV3.sendPacket(Options.UnBlockHWID.ToString() + " " + text3);
				EmbedBuilder val3 = new EmbedBuilder();
				val3.WithTitle("UnBlock HWID!");
				val3.WithDescription("HWID UnBlocked Sucessfully \n HWID: " + text3);
				val3.WithColor(Color.Green);
				await message.Channel.SendMessageAsync("", false, val3.Build(), (RequestOptions)null, (AllowedMentions)null, (MessageReference)null, (MessageComponent)null, (ISticker[])null, (Embed[])null, (MessageFlags)0);
				return Task.CompletedTask;
			}
			if (message.Content == "!genunban" && message.Channel.Id == 1005227486608625694)
			{
				LoginSystemV1 loginSystemV4 = new LoginSystemV1("45.142.115.67");
				string text4 = loginSystemV4.GenerateLicense();
				loginSystemV4.sendPacket(Options.GenerateLicense.ToString() + " UNBAN-" + text4);
				EmbedBuilder val4 = new EmbedBuilder();
				val4.WithTitle("Key Generation");
				val4.WithDescription("Key Generation Sucessfully \n KEY: UNBAN-" + text4);
				val4.WithColor(Color.Green);
				await message.Channel.SendMessageAsync("", false, val4.Build(), (RequestOptions)null, (AllowedMentions)null, (MessageReference)null, (MessageComponent)null, (ISticker[])null, (Embed[])null, (MessageFlags)0);
			}
			if (message.Content == "!genwoofer" && message.Channel.Id == 1005227486608625694)
			{
				LoginSystemV1 loginSystemV5 = new LoginSystemV1("45.142.115.67");
				string text5 = loginSystemV5.GenerateLicense();
				loginSystemV5.sendPacket(Options.GenerateLicense.ToString() + " SPOOFER-" + text5);
				EmbedBuilder val5 = new EmbedBuilder();
				val5.WithTitle("Key Generation");
				val5.WithDescription("Key Generation Sucessfully \n KEY: SPOOFER-" + text5);
				val5.WithColor(Color.Green);
				await message.Channel.SendMessageAsync("", false, val5.Build(), (RequestOptions)null, (AllowedMentions)null, (MessageReference)null, (MessageComponent)null, (ISticker[])null, (Embed[])null, (MessageFlags)0);
			}
			if (message.Content.StartsWith("!redeem"))
			{
				LoginSystemV1 loginSystemV6 = new LoginSystemV1("45.142.115.67");
				Console.WriteLine("+++++++++++++CALLED+++++++++++++");
				string license = message.Content.Replace("!redeem ", "");
				EmbedBuilder help = new EmbedBuilder();
				help.WithTitle("redeem key");
				if (loginSystemV6.Checklicense(Options.License, license))
				{
					help.WithDescription("redeem Key sucessfully! ");
					IGuildUser val6 = (IGuildUser)message.Author;
					//IRole role = ((IGuildChannel)message.Channel..GetRole(993187269265600563uL);
					//await val6.AddRoleAsync(role, (RequestOptions)null);
				}
				else
				{
					help.WithDescription("redeem Key failed (invalid license)! ");
				}
				help.WithColor(Color.Teal);
				await message.Channel.SendMessageAsync("", false, help.Build(), (RequestOptions)null, (AllowedMentions)null, (MessageReference)null, (MessageComponent)null, (ISticker[])null, (Embed[])null, (MessageFlags)0);
			}
			if (message.Content == "!ping")
			{
				Console.WriteLine("+++++++++++++++++++++++");
			}
			if (message.Content == "!help")
			{
				EmbedBuilder val7 = new EmbedBuilder();
				val7.WithTitle("Help");
				val7.WithDescription("!redeem <Key> \n can be use for redeem your key - ");
				val7.WithColor(Color.Teal);
				await message.Channel.SendMessageAsync("", false, val7.Build(), (RequestOptions)null, (AllowedMentions)null, (MessageReference)null, (MessageComponent)null, (ISticker[])null, (Embed[])null, (MessageFlags)0);
			}
			return Task.CompletedTask;
		}
	}
}
