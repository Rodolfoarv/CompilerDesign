      program rain
      real r, t, sum
      integer m

      read (*, *) t
      sum = 0.0
      do 10 m = 1, 12
          sum = sum + r(m, t)
10    continue
      write (*,*) 'Annual rainfall is', sum, 'inches'

      stop
      end

      real function r(m,t)
      integer m
      real t

      r = 0.1 * t * (m ** 2 + 14 * m + 46)
      if (r .lt. 0) r = 0.0

      return
      end
