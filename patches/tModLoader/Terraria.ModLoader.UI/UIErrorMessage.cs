using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace Terraria.ModLoader.UI
{
	internal class UIErrorMessage : UIState
	{
		private UIMessageBox message = new UIMessageBox("");
		private int gotoMenu = 0;
		private string file;

		public override void OnInitialize()
		{
			UIElement area = new UIElement();
			area.Width.Set(0f, 0.8f);
			area.Top.Set(200f, 0f);
			area.Height.Set(-240f, 1f);
			area.HAlign = 0.5f;
			message.Width.Set(0f, 1f);
			message.Height.Set(0f, 0.8f);
			message.HAlign = 0.5f;
			area.Append(message);
			UITextPanel button = new UITextPanel("Continue", 0.7f, true);
			button.Width.Set(-10f, 0.5f);
			button.Height.Set(50f, 0f);
			button.VAlign = 1f;
			button.Top.Set(-30f, 0f);
			button.OnMouseOver += new UIElement.MouseEvent(FadedMouseOver);
			button.OnMouseOut += new UIElement.MouseEvent(FadedMouseOut);
			button.OnClick += new UIElement.MouseEvent(ContinueClick);
			area.Append(button);
			UITextPanel button2 = new UITextPanel("Open Logs", 0.7f, true);
			button2.CopyStyle(button);
			button2.HAlign = 1f;
			button2.OnMouseOver += new UIElement.MouseEvent(FadedMouseOver);
			button2.OnMouseOut += new UIElement.MouseEvent(FadedMouseOut);
			button2.OnClick += new UIElement.MouseEvent(OpenFile);
			area.Append(button2);
			base.Append(area);
		}

		public override void OnActivate()
		{
			Netplay.disconnect = true;
		}

		internal void SetMessage(string text)
		{
			message.SetText(text);
		}

		internal void SetGotoMenu(int gotoMenu)
		{
			this.gotoMenu = gotoMenu;
		}

		internal void SetFile(string file)
		{
			this.file = file;
		}

		private static void FadedMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(12, -1, -1, 1);
			((UIPanel)evt.Target).BackgroundColor = new Color(73, 94, 171);
		}

		private static void FadedMouseOut(UIMouseEvent evt, UIElement listeningElement)
		{
			((UIPanel)evt.Target).BackgroundColor = new Color(63, 82, 151) * 0.7f;
		}

		private void ContinueClick(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(10, -1, -1, 1);
			Main.menuMode = this.gotoMenu;
		}

		private void OpenFile(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(10, -1, -1, 1);
			Process.Start(file);
		}
	}
}
