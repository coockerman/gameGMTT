using UnityEngine;

public class SkillHoiKi : SkillHoiPhuc
{
    [SerializeField] PlayerManaManager playerMana;
    protected override void Start()
    {
        SAVE_LV = "lvMana";
        base.Start();
    }
    public override void OnHoiPhuc()
    {
        base.OnHoiPhuc();
        hoiPhuc = playerMana.playerMaxMana * dataLVHoiPhuc[lvHoiPhuc] * 0.01f;
        playerMana.HoiMana((int)hoiPhuc);
    }
    
    protected override void SetChuThich()
    {
        ChuThichHoiPhuc.text = "Hồi lại " + dataLVHoiPhuc[lvHoiPhuc] + "% KI tối đa ";
        base.SetChuThich();
    }
}
