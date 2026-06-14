using System.Collections;

public interface IAnimationPlayer
{
    IEnumerator Play(AnimRequest animRequest);
}