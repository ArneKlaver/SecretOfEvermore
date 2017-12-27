using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : EverMorePanel
{
    private CharacterPlayer _player;
    //private CharacterPlayer _dog;

    public GameObject RootObject;
    // character stats
    private Text _hPText;
    private Text _levelText;
    private Text _expText;
    private Text _expNeededText;
    private Text _pickup1Text;
    private Text _pickup2Text;
    private Text _pickup3Text;
    private Text _pickup4Text;
    private Text _attackText;
    private Text _defendText;
    private Text _magicDefText;
    private Text _evadeText;
    private Text _hitText;
    // character upgrade
    private Text _hPUpgradeText;
    private Text _attackUpgradeText;
    private Text _defendUpgradeText;
    private Text _magicDefUpgradeText;
    private Text _evadeUpgradeText;
    private Text _hitUpgradeText;
    // selected items
    private Text _weaponText;
    private Text _ArmoreText;

    public void Start()
    {
        _player = GameManager.GetCharacterManager().GetPlayer() as CharacterPlayer;
        //_dog = GameManager.GetCharacterManager().GetDog() as CharacterPlayer;
        // get character stats variables
        _hPText = RootObject.transform.Find("HPValue").GetComponent<Text>();
        _levelText = RootObject.transform.Find("LevelValue").GetComponent<Text>();
        _expText = RootObject.transform.Find("ExpValue").GetComponent<Text>();
        _expNeededText = RootObject.transform.Find("ExpNeededValue").GetComponent<Text>();
        _pickup1Text = RootObject.transform.Find("Pickup1Value").GetComponent<Text>();
        _pickup2Text = RootObject.transform.Find("Pickup2Value").GetComponent<Text>();
        _pickup3Text = RootObject.transform.Find("Pickup3Value").GetComponent<Text>();
        _pickup4Text = RootObject.transform.Find("Pickup4Value").GetComponent<Text>();
        _attackText = RootObject.transform.Find("AttackValue").GetComponent<Text>();
        _defendText = RootObject.transform.Find("DefendValue").GetComponent<Text>();
        _magicDefText = RootObject.transform.Find("MagicDefValue").GetComponent<Text>();
        _evadeText = RootObject.transform.Find("EvadeValue").GetComponent<Text>();
        _hitText = RootObject.transform.Find("HitValue").GetComponent<Text>();
        // get character upgrade variables
        _hPUpgradeText = RootObject.transform.Find("HPUpgradeValue").GetComponent<Text>();
        _attackUpgradeText = RootObject.transform.Find("AttackUpgradeValue").GetComponent<Text>();
        _defendUpgradeText = RootObject.transform.Find("DefendUpgradeValue").GetComponent<Text>();
        _magicDefUpgradeText = RootObject.transform.Find("MagicDefUpgradeValue").GetComponent<Text>();
        _evadeUpgradeText = RootObject.transform.Find("EvadeUpgradeValue").GetComponent<Text>();
        _hitUpgradeText = RootObject.transform.Find("HitUpgradeValue").GetComponent<Text>();
        // get the weapon and armore text
        _weaponText = RootObject.transform.Find("SelectedWeaponText").GetComponent<Text>();
        _ArmoreText = RootObject.transform.Find("SelectedArmorText").GetComponent<Text>();
        UpdateStats();
    }
    // update all the text with the character data
    public void UpdateStats()
    {
        _hPText.text = _player.Health.ToString();
        _levelText.text = _player.Level.ToString();
        _expText.text = _player.Exp.ToString();
        _expNeededText.text = _player.ExpNeeded.ToString();
        _pickup1Text.text = "0";
        _pickup2Text.text = "0";
        _pickup3Text.text = "0";
        _pickup4Text.text = "0";
        _attackText.text = _player.AttackPower.ToString();
        _defendText.text = _player.DefendPower.ToString();
        _magicDefText.text = _player.MagicDef.ToString();
        _evadeText.text = _player.Evade.ToString();
        _hitText.text = _player.HitChance.ToString();
    }
    public void WeaponHovered(int buttonNumber)
    {
        // return if the Weapon list is smaller then the button number
        if (Inventory.Weapon.Count <= buttonNumber)
            return;

        // get the Weapon from the inventory
        Item item = Inventory.Weapon[buttonNumber];
        _hPUpgradeText.text = "+ " + item.UpgradeValues.MaxHealth.ToString();
        _attackUpgradeText.text = "+ " + item.UpgradeValues.Attack.ToString();
        _defendUpgradeText.text = "+ " + item.UpgradeValues.Defend.ToString();
        _magicDefUpgradeText.text = "+ " + item.UpgradeValues.MagicDef.ToString();
        _evadeUpgradeText.text = "+ " + item.UpgradeValues.Evade.ToString();
        _hitUpgradeText.text = "+ " + item.UpgradeValues.Hit.ToString();
    }
    public void ArmoreHovered(int buttonNumber)
    {
        // return if the Armor list is smaller then the button number
        if (Inventory.Armor.Count <= buttonNumber)
            return;

        // get the Armor from the inventory
        Item item = Inventory.Armor[buttonNumber];
        _hPUpgradeText.text = "+ " + item.UpgradeValues.MaxHealth.ToString();
        _attackUpgradeText.text = "+ " + item.UpgradeValues.Attack.ToString();
        _defendUpgradeText.text = "+ " + item.UpgradeValues.Defend.ToString();
        _magicDefUpgradeText.text = "+ " + item.UpgradeValues.MagicDef.ToString();
        _evadeUpgradeText.text = "+ " + item.UpgradeValues.Evade.ToString();
        _hitUpgradeText.text = "+ " + item.UpgradeValues.Hit.ToString();
    }
    public void OnClickedWeapon(int buttonNumber)
    {
        if (Inventory.Weapon.Count <= buttonNumber)
            return;
        Item item = Inventory.Weapon[buttonNumber];
        Item selectedWeapon = Inventory.SelectedWeapon;
        _player.MaxHealth += item.UpgradeValues.MaxHealth - selectedWeapon.UpgradeValues.MaxHealth;
        _player.AttackPower += item.UpgradeValues.Attack - selectedWeapon.UpgradeValues.Attack;
        _player.DefendPower += item.UpgradeValues.Defend - selectedWeapon.UpgradeValues.Defend;
        _player.MagicDef += item.UpgradeValues.MagicDef - selectedWeapon.UpgradeValues.MagicDef;
        _player.Evade += item.UpgradeValues.Evade - selectedWeapon.UpgradeValues.Evade;
        _player.HitChance += item.UpgradeValues.Hit - selectedWeapon.UpgradeValues.Hit;

        Inventory.SelectedWeapon = item;
        _weaponText.text = item.ItemName;
        UpdateStats();
    }
    public void OnClickedArmore(int buttonNumber)
    {
        if (Inventory.Armor.Count <= buttonNumber)
            return;
        Item item = Inventory.Armor[buttonNumber];
        Item selectedArmore = Inventory.SelectedArmor;
        _player.MaxHealth += item.UpgradeValues.MaxHealth - selectedArmore.UpgradeValues.MaxHealth;
        _player.AttackPower += item.UpgradeValues.Attack - selectedArmore.UpgradeValues.Attack;
        _player.DefendPower += item.UpgradeValues.Defend - selectedArmore.UpgradeValues.Defend;
        _player.MagicDef += item.UpgradeValues.MagicDef - selectedArmore.UpgradeValues.MagicDef;
        _player.Evade += item.UpgradeValues.Evade - selectedArmore.UpgradeValues.Evade;
        _player.HitChance += item.UpgradeValues.Hit - selectedArmore.UpgradeValues.Hit;

        Inventory.SelectedArmor = item;
        _ArmoreText.text = item.ItemName;
        UpdateStats();
    }
    public void LeaveHover()
    {
        // Set all values to ""
        _hPUpgradeText.text = "";
        _attackUpgradeText.text = "";
        _defendUpgradeText.text = "";
        _magicDefUpgradeText.text = "";
        _evadeUpgradeText.text = "";
        _hitUpgradeText.text = "";
    }
}
