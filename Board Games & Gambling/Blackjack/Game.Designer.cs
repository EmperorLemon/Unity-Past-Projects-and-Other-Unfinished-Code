
namespace Blackjack
{
    partial class Blackjack_Table
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hitButton = new System.Windows.Forms.Button();
            this.standButton = new System.Windows.Forms.Button();
            this.doubleDownButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.playerCardView = new System.Windows.Forms.ListView();
            this.dealerCardView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.playerValue = new System.Windows.Forms.Label();
            this.dealerValue = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.betInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.warningText = new System.Windows.Forms.Label();
            this.cashText = new System.Windows.Forms.Label();
            this.resultText = new System.Windows.Forms.Label();
            this.newGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hitButton
            // 
            this.hitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hitButton.Location = new System.Drawing.Point(566, 114);
            this.hitButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.hitButton.Name = "hitButton";
            this.hitButton.Size = new System.Drawing.Size(56, 33);
            this.hitButton.TabIndex = 1;
            this.hitButton.Text = "Hit";
            this.hitButton.UseVisualStyleBackColor = true;
            this.hitButton.Click += new System.EventHandler(this.HitButton_Click);
            // 
            // standButton
            // 
            this.standButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.standButton.Location = new System.Drawing.Point(630, 114);
            this.standButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.standButton.Name = "standButton";
            this.standButton.Size = new System.Drawing.Size(71, 34);
            this.standButton.TabIndex = 2;
            this.standButton.Text = "Stand";
            this.standButton.UseVisualStyleBackColor = true;
            this.standButton.Click += new System.EventHandler(this.StandButton_Click);
            // 
            // doubleDownButton
            // 
            this.doubleDownButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.doubleDownButton.Location = new System.Drawing.Point(709, 114);
            this.doubleDownButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.doubleDownButton.Name = "doubleDownButton";
            this.doubleDownButton.Size = new System.Drawing.Size(89, 59);
            this.doubleDownButton.TabIndex = 3;
            this.doubleDownButton.Text = "Double Down";
            this.doubleDownButton.UseVisualStyleBackColor = true;
            this.doubleDownButton.Click += new System.EventHandler(this.DoubleDownButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(431, 473);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 30);
            this.textBox1.TabIndex = 4;
            // 
            // playerCardView
            // 
            this.playerCardView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playerCardView.HideSelection = false;
            this.playerCardView.Location = new System.Drawing.Point(12, 53);
            this.playerCardView.Name = "playerCardView";
            this.playerCardView.Size = new System.Drawing.Size(151, 257);
            this.playerCardView.TabIndex = 5;
            this.playerCardView.UseCompatibleStateImageBehavior = false;
            this.playerCardView.View = System.Windows.Forms.View.List;
            // 
            // dealerCardView
            // 
            this.dealerCardView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dealerCardView.HideSelection = false;
            this.dealerCardView.Location = new System.Drawing.Point(191, 53);
            this.dealerCardView.Name = "dealerCardView";
            this.dealerCardView.Size = new System.Drawing.Size(151, 257);
            this.dealerCardView.TabIndex = 6;
            this.dealerCardView.UseCompatibleStateImageBehavior = false;
            this.dealerCardView.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Player Has:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(221, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Dealer Has:";
            // 
            // playerValue
            // 
            this.playerValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playerValue.AutoSize = true;
            this.playerValue.Location = new System.Drawing.Point(24, 332);
            this.playerValue.Name = "playerValue";
            this.playerValue.Size = new System.Drawing.Size(116, 23);
            this.playerValue.TabIndex = 9;
            this.playerValue.Text = "Card Value: 0";
            this.playerValue.TextChanged += new System.EventHandler(this.playerValue_TextChanged);
            // 
            // dealerValue
            // 
            this.dealerValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dealerValue.AutoSize = true;
            this.dealerValue.Location = new System.Drawing.Point(206, 332);
            this.dealerValue.Name = "dealerValue";
            this.dealerValue.Size = new System.Drawing.Size(116, 23);
            this.dealerValue.TabIndex = 10;
            this.dealerValue.Text = "Card Value: 0";
            this.dealerValue.TextChanged += new System.EventHandler(this.dealerValue_TextChanged);
            // 
            // startButton
            // 
            this.startButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startButton.Location = new System.Drawing.Point(374, 54);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 55);
            this.startButton.TabIndex = 11;
            this.startButton.Text = "Start Game";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // betInput
            // 
            this.betInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.betInput.Location = new System.Drawing.Point(709, 46);
            this.betInput.Name = "betInput";
            this.betInput.Size = new System.Drawing.Size(100, 30);
            this.betInput.TabIndex = 12;
            this.betInput.TextChanged += new System.EventHandler(this.betInput_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(684, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Place Bet Amount";
            // 
            // warningText
            // 
            this.warningText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.warningText.AutoSize = true;
            this.warningText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.warningText.ForeColor = System.Drawing.Color.Red;
            this.warningText.Location = new System.Drawing.Point(578, 79);
            this.warningText.Name = "warningText";
            this.warningText.Size = new System.Drawing.Size(279, 25);
            this.warningText.TabIndex = 14;
            this.warningText.Text = "Please Enter another bet amount";
            // 
            // cashText
            // 
            this.cashText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cashText.AutoSize = true;
            this.cashText.Location = new System.Drawing.Point(639, 188);
            this.cashText.Name = "cashText";
            this.cashText.Size = new System.Drawing.Size(198, 23);
            this.cashText.TabIndex = 15;
            this.cashText.Text = "Cash Remaining: $1000";
            // 
            // resultText
            // 
            this.resultText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.resultText.AutoSize = true;
            this.resultText.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.resultText.ForeColor = System.Drawing.Color.Red;
            this.resultText.Location = new System.Drawing.Point(348, 186);
            this.resultText.Name = "resultText";
            this.resultText.Size = new System.Drawing.Size(130, 25);
            this.resultText.TabIndex = 16;
            this.resultText.Text = "DEALER BUST";
            // 
            // newGameButton
            // 
            this.newGameButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newGameButton.Location = new System.Drawing.Point(374, 316);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(75, 55);
            this.newGameButton.TabIndex = 17;
            this.newGameButton.Text = "New Game?";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // Blackjack_Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 450);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.resultText);
            this.Controls.Add(this.cashText);
            this.Controls.Add(this.warningText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.betInput);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.dealerValue);
            this.Controls.Add(this.playerValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dealerCardView);
            this.Controls.Add(this.playerCardView);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.doubleDownButton);
            this.Controls.Add(this.standButton);
            this.Controls.Add(this.hitButton);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "Blackjack_Table";
            this.Text = "Dealer has:";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button hitButton;
        private System.Windows.Forms.Button standButton;
        private System.Windows.Forms.Button doubleDownButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView playerCardView;
        private System.Windows.Forms.ListView dealerCardView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label playerValue;
        private System.Windows.Forms.Label dealerValue;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox betInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label warningText;
        private System.Windows.Forms.Label cashText;
        private System.Windows.Forms.Label resultText;
        private System.Windows.Forms.Button newGameButton;
    }
}

